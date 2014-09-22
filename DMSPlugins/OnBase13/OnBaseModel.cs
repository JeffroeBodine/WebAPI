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
        private string _userName = string.Empty;
        private Application App { get; set; }
        private readonly string _tempFolder;

        public OnBaseUnityModel(string serviceURL, string dataSource, string userName, SecureString password)
        {
            _userName = userName;
            App = OBConnection(serviceURL, dataSource, userName, password);

            _tempFolder = Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory").ToString(), "CompassTemporaryFileStore");
            CreateFolderIfItDoesntAlreadyExist();
        }

        private static Application OBConnection(string serviceURL, string dataSource, string userName, SecureString password)
        {
            var hylandApplication = Cache.Applications.Where(cachedApplication => cachedApplication.UserName == userName).Select(ca => ca.Application).SingleOrDefault();

            if (hylandApplication == null)
            {
                var onBaseAuthProperties = Application.CreateOnBaseAuthenticationProperties(serviceURL, userName, password.Insecure(), dataSource);

                hylandApplication = Application.Connect(onBaseAuthProperties);

                Cache.Applications.Add(new WApplication(userName, hylandApplication));
            }
            return hylandApplication;
        }

        public DocumentTypeList GetDocumentTypes()
        {
            var documentTypes = new DocumentTypeList();
            try
            {
                foreach (var udtg in App.Core.DocumentTypeGroups)
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
            catch (SessionNotFoundException snfex)
            {
                Cache.Clear(_userName);
                throw;
            }

            return documentTypes;
        }

        public DocumentType GetDocumentType(string id)
        {
            var obDocumentType = App.Core.DocumentTypes.Find(long.Parse(id));
            return new DocumentType(obDocumentType.ID, obDocumentType.Name);
        }

        public IEnumerable<KeywordType> GetKeywordTypes()
        {
            var keywordTypes = new List<KeywordType>();

            keywordTypes.AddRange(App.Core.KeywordTypes.Select(ukwt => new KeywordType(ukwt.ID, ukwt.Name, GetSystemTypeFromUnityType(ukwt.DataType), ukwt.DefaultValue)));

            return keywordTypes;
        }

        public KeywordType GetKeywordType(string id)
        {
            return GetKeywordTypes().FirstOrDefault(x => x.Id == long.Parse(id));
        }

        public Document GetDocument(string id)
        {
            var uDocument = App.Core.GetDocumentByID(long.Parse(id));

            var documentMetaData = GetDocumentMetaData(uDocument, App.Core.Retrieval.Default);

            return new Document(uDocument.ID, uDocument.Name, uDocument.DateStored, uDocument.DateStored,
                                uDocument.CreatedBy.Name, uDocument.DocumentType.ID, documentMetaData);

        }

        public List<Document> GetDocuments(string compassNumber)
        {
            var documentQuery = App.Core.CreateDocumentQuery();
            documentQuery.AddKeyword("Compass Number", compassNumber);
            documentQuery.AddSort(DocumentQuery.SortAttribute.DocumentDate, false);

            DocumentList documentList = null;
            try
            {
                documentList = documentQuery.Execute(500);
            }
            catch (SessionNotFoundException snfex)
            {
                Cache.Clear(_userName);
                throw;
            }
          
            var documents = new List<Document>();

            foreach (var uDocument in documentList)
            {
                documents.Add(new Document(uDocument.ID, uDocument.Name, uDocument.DateStored, uDocument.DateStored, uDocument.CreatedBy.Name, uDocument.DocumentType.ID, null));
            }

            return documents;

        }

        public DocumentMetaData GetDocumentMetaData(long documentId)
        {
            var uDocument = App.Core.GetDocumentByID(documentId);
            return GetDocumentMetaData(uDocument, App.Core.Retrieval.Default);
        }

        public Stream GetFileData(string documentId)
        {
            CleanUpTempDirectory();

            var uDocument = App.Core.GetDocumentByID(long.Parse(documentId));

            var rend = uDocument.DefaultRenditionOfLatestRevision;

            string filePath;
            using (PageData unityPageData = App.Core.Retrieval.Default.GetDocument(rend))
            {
                filePath = _tempFolder + @"\" + uDocument.ID.ToString() + "." + unityPageData.Extension;
                Utility.WriteStreamToFile(unityPageData.Stream, filePath);
            }
            return new FileStream(filePath, FileMode.Open, FileAccess.Read);

        }

        public Keywords GetKeywords(string documentId)
        {
            var keywords = new Keywords();

            var uDocument = App.Core.GetDocumentByID(long.Parse(documentId));
            foreach (KeywordRecord uKeywordRecord in uDocument.KeywordRecords.Where(x => x.KeywordRecordType.RecordType != RecordType.MultiInstance))
            {
                foreach (Keyword uKeyword in uKeywordRecord.Keywords)
                {
                    var keywordType = new KeywordType(uKeyword.KeywordType.ID,
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

            return keywords;
        }

        public string CreateDocument(PutDocumentParams @params, List<string> filePaths)
        {
            var storeDocProperties = App.Core.Storage.CreateStoreNewDocumentProperties(
                  App.Core.DocumentTypes.Find(@params.DocumentTypeId), App.Core.FileTypes.Find(ImageFileFormatId));

            @params.Keywords.OrEmptyIfNull().ForEach(x =>
                {
                    var hylandKeywordType = App.Core.KeywordTypes.Find(x.KeywordType.Id);
                    storeDocProperties.AddKeyword(HylandKeywordFrom(x, hylandKeywordType));
                });

            storeDocProperties.DocumentDate = DateTime.Now;
            storeDocProperties.Comment = "This is a comment";
            storeDocProperties.Options = StoreDocumentOptions.SkipWorkflow;

            return App.Core.Storage.StoreNewDocument(filePaths, storeDocProperties).ID.ToString();

        }

        #region Privates

        private void CreateFolderIfItDoesntAlreadyExist()
        {
            if (!Directory.Exists(_tempFolder))
                Directory.CreateDirectory(_tempFolder);
        }

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
            if (Directory.Exists(_tempFolder))
            {
                foreach (var fileName in Directory.GetFiles(_tempFolder))
                {
                    if (File.GetCreationTime(fileName) < DateTime.Now.AddMinutes(-5))
                    {
                        File.Delete(fileName);
                    }
                }
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

        #endregion

    }
}
