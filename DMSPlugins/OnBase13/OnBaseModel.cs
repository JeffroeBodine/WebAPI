using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using Hyland.Unity;
using ObjectLibrary;
using ObjectLibrary.Collections;
using Document = ObjectLibrary.Document;
using DocumentType = ObjectLibrary.DocumentType;
using DocumentTypeList = ObjectLibrary.Collections.DocumentTypeList;
using Keyword = Hyland.Unity.Keyword;
using KeywordType = ObjectLibrary.KeywordType;

namespace DMSPlugins.OnBase13
{
    public class OnBaseUnityModel
    {
        private const int ImageFileFormatId = 2;
        private string ServiceUrl { get; set; }
        private string DataSource { get; set; }
        private string UserName { get; set; }
        private SecureString Password { get; set; }
        private string tempFolder;

        public OnBaseUnityModel(string serviceURL, string dataSource, string userName, SecureString password)
        {
            ServiceUrl = serviceURL;
            DataSource = dataSource;
            UserName = userName;
            Password = password;

            tempFolder = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "CompassTemporaryFileStore");
            CreateFolderIfItDoesntAlreadyExist();
        }

        private void CreateFolderIfItDoesntAlreadyExist()
        {
            if (!Directory.Exists(tempFolder))
                Directory.CreateDirectory(tempFolder);
        }

        private Application OBConnection(string serviceURL, string dataSource, string userName, SecureString password)
        {
            Hyland.Unity.OnBaseAuthenticationProperties onBaseAuthProperties = Hyland.Unity.Application.CreateOnBaseAuthenticationProperties(serviceURL, userName, password.Insecure(), dataSource);
            return Hyland.Unity.Application.Connect(onBaseAuthProperties);
        }

        public DocumentTypeList GetDocumentTypes()
        {
            var documentTypes = new DocumentTypeList();
            using (var app = OBConnection(ServiceUrl, DataSource, UserName, Password))
            {
                foreach (var udtg in app.Core.DocumentTypeGroups)
                {
                    var dtg = new DocumentType(udtg.ID, udtg.Name);
                    documentTypes.Add(dtg);

                    if (udtg.DocumentTypes != null)
                    {
                        foreach (var udt in udtg.DocumentTypes)
                        {
                            if (dtg.DocumentTypeList == null)
                                dtg.DocumentTypeList = new DocumentTypeList();

                            dtg.DocumentTypeList.Add(new DocumentType(udt.ID, udt.Name));
                        }
                    }
                }
            }
            return documentTypes;
        }

        public DocumentType GetDocumentType(string id)
        {
            using (var app = OBConnection(ServiceUrl, DataSource, UserName, Password))
            {
                var obDocumentType = app.Core.DocumentTypes.Find(long.Parse(id));
                return new DocumentType(obDocumentType.ID, obDocumentType.Name);
            }
        }

        public IEnumerable<KeywordType> GetKeywordTypes()
        {
            var keywordTypes = new List<KeywordType>();
            using (var app = OBConnection(ServiceUrl, DataSource, UserName, Password))
            {
                keywordTypes.AddRange(app.Core.KeywordTypes.Select(ukwt => new KeywordType(ukwt.ID, ukwt.Name, GetSystemTypeFromUnityType(ukwt.DataType), ukwt.DefaultValue)));
            }
            return keywordTypes;
        }

        public KeywordType GetKeywordType(string id)
        {
            return GetKeywordTypes().FirstOrDefault(x => x.Id == long.Parse(id));
        }

        public Document GetDocument(string id)
        {
            using (var app = OBConnection(ServiceUrl, DataSource, UserName, Password))
            {
                var uDocument = app.Core.GetDocumentByID(long.Parse(id));

                var documentMetaData = GetDocumentMetaData(uDocument, app.Core.Retrieval.Default);

                return new Document(uDocument.ID, uDocument.Name, uDocument.DateStored, uDocument.DateStored,
                                    uDocument.CreatedBy.Name, uDocument.DocumentType.ID, documentMetaData);
            }
        }

        public List<Document> GetDocuments(string compassNumber)
        {
            using (var app = OBConnection(ServiceUrl, DataSource, UserName, Password))
            {
                var documentQuery = app.Core.CreateDocumentQuery();
                documentQuery.AddKeyword("Compass Number", compassNumber);
                documentQuery.AddSort(DocumentQuery.SortAttribute.DocumentDate, false);
                var documentList = documentQuery.Execute(500);

                var documents = new List<Document>();

                foreach (var uDocument in documentList)
                {
                    //var documentMetaData = GetDocumentMetaData(uDocument, app.Core.Retrieval.Default);

                    documents.Add(new Document(uDocument.ID, uDocument.Name, uDocument.DateStored, uDocument.DateStored, uDocument.CreatedBy.Name, uDocument.DocumentType.ID, null));
                }

                return documents;
            }
        }

        public DocumentMetaData GetDocumentMetaData(long documentId)
        {
            using (var app = OBConnection(ServiceUrl, DataSource, UserName, Password))
            {
                var uDocument = app.Core.GetDocumentByID(documentId);
                return GetDocumentMetaData(uDocument, app.Core.Retrieval.Default);
            }
        }

        public Stream GetFileData(string documentId)
        {
            CleanUpTempDirectory();

            using (var app = OBConnection(ServiceUrl, DataSource, UserName, Password))
            {
                var uDocument = app.Core.GetDocumentByID(long.Parse(documentId));

                var rend = uDocument.DefaultRenditionOfLatestRevision;

                string filePath;
                using (PageData unityPageData = app.Core.Retrieval.Default.GetDocument(rend))
                {
                    filePath = tempFolder + @"\" + uDocument.ID.ToString() + "." + unityPageData.Extension;
                    Utility.WriteStreamToFile(unityPageData.Stream, filePath);
                }
                return new FileStream(filePath, FileMode.Open, FileAccess.Read);
            }
        }

        public Keywords GetKeywords(string documentId)
        {
            var keywords = new Keywords();

            using (var app = OBConnection(ServiceUrl, DataSource, UserName, Password))
            {
                var uDocument = app.Core.GetDocumentByID(long.Parse(documentId));
                foreach (KeywordRecord uKeywordRecord in uDocument.KeywordRecords.Where(x => x.KeywordRecordType.RecordType != RecordType.MultiInstance))
                {
                    foreach (Keyword uKeyword in uKeywordRecord.Keywords)
                    {
                        var keywordType = new ObjectLibrary.KeywordType(uKeyword.KeywordType.ID,
                                                                        uKeyword.KeywordType.Name,
                                                                        GetSystemTypeFromUnityType(uKeyword.KeywordType.DataType),
                                                                        uKeyword.KeywordType.DefaultValue);
                        ObjectLibrary.Keyword keyword = null;
                        switch (uKeyword.KeywordType.DataType)
                        {
                            case KeywordDataType.AlphaNumeric:
                                keyword = new ObjectLibrary.Keyword(keywordType, uKeyword.AlphaNumericValue);
                                break;
                            case KeywordDataType.Currency:
                            case KeywordDataType.SpecificCurrency:
                                keyword = new ObjectLibrary.Keyword(keywordType, uKeyword.CurrencyValue);
                                break;
                            case KeywordDataType.Date:
                            case KeywordDataType.DateTime:
                                keyword = new ObjectLibrary.Keyword(keywordType, uKeyword.DateTimeValue);
                                break;
                            case KeywordDataType.FloatingPoint:
                                keyword = new ObjectLibrary.Keyword(keywordType, uKeyword.FloatingPointValue);
                                break;
                            case KeywordDataType.Numeric20:
                                keyword = new ObjectLibrary.Keyword(keywordType, uKeyword.Numeric20Value);
                                break;
                            case KeywordDataType.Numeric9:
                                keyword = new ObjectLibrary.Keyword(keywordType, uKeyword.Numeric9Value);
                                break;
                        }
                        keywords.Add(keyword);
                    }
                }
            }
            return keywords;
        }

        public string CreateDocument(CreateDocumentParms parms)
        {
            using (var app = OBConnection(ServiceUrl, DataSource, UserName, Password))
            {
                var storeDocProperties = app.Core.Storage.CreateStoreNewDocumentProperties(
                    app.Core.DocumentTypes.Find(parms.DocumentTypeId), app.Core.FileTypes.Find(ImageFileFormatId));

                parms.Keywords.ForEach(x =>
                    {
                        var hylandKeywordType = app.Core.KeywordTypes.Find(x.KeywordType.Id);
                        storeDocProperties.AddKeyword(HylandKeywordFrom(x, hylandKeywordType));
                    });

                //return app.Core.Storage.StoreNewDocument(new List<string>(), storeDocProperties).ID.ToString();

                PageData pgData = app.Core.Storage.CreatePageData(new MemoryStream(), "???");
           
                return app.Core.Storage.StoreNewDocument(pgData, storeDocProperties).ID.ToString();
            }
        }

        private Keyword HylandKeywordFrom(ObjectLibrary.Keyword keyword, Hyland.Unity.KeywordType keywordType)
        {
            switch (keywordType.DataType)
            {
                case KeywordDataType.AlphaNumeric:
                    return keywordType.CreateKeyword(keyword.StringValue);
                case KeywordDataType.Currency:
                case KeywordDataType.SpecificCurrency:
                    return keywordType.CreateKeyword(keyword.DecimalValue);
                case KeywordDataType.Date:
                case KeywordDataType.DateTime:
                    return keywordType.CreateKeyword(keyword.DateTimeValue);
                case KeywordDataType.FloatingPoint:
                    return keywordType.CreateKeyword(keyword.DoubleValue);
                case KeywordDataType.Numeric20:
                case KeywordDataType.Numeric9:
                    return keywordType.CreateKeyword(keyword.IntValue);
                default:
                    return null;
            }
        }

        #region Privates
        private DocumentMetaData GetDocumentMetaData(Hyland.Unity.Document document, DefaultDataProvider provider)
        {
            var rend = document.DefaultRenditionOfLatestRevision;

            using (PageData unityPageData = provider.GetDocument(rend))
            {
                return new DocumentMetaData(unityPageData.Extension, rend.FileType.MimeType, (int)rend.NumberOfPages);
            }
        }

        private Type GetSystemTypeFromUnityType(KeywordDataType unityKeywordDataType)
        {
            switch (unityKeywordDataType)
            {

                case KeywordDataType.AlphaNumeric:
                case KeywordDataType.Undefined:
                case KeywordDataType.Currency:
                case KeywordDataType.SpecificCurrency:
                    return typeof(String);

                case KeywordDataType.Numeric9:
                case KeywordDataType.Numeric20:
                    return typeof(Int32);

                case KeywordDataType.FloatingPoint:
                    return typeof(Decimal);

                case KeywordDataType.Date:
                case KeywordDataType.DateTime:
                    return typeof(DateTime);

                default:
                    throw new ArgumentOutOfRangeException("unityKeywordDataType");
            }
        }

        private void CleanUpTempDirectory()
        {
            if (Directory.Exists(tempFolder))
            {
                foreach (var fileName in Directory.GetFiles(tempFolder))
                {
                    if (File.GetCreationTime(fileName) < DateTime.Now.AddMinutes(-5))
                    {
                        File.Delete(fileName);
                    }
                }
            }
        }
        #endregion

    }
}
