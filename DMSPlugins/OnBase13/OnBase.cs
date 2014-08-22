using System.Collections.Generic;
using System.IO;
using ObjectLibrary;
using ObjectLibrary.Collections;

namespace DMSPlugins.OnBase13
{
    public class OnBase
    {
        private const string ServiceURL = "http://vm-qatrunk-ob13/AppServer/Service.asmx";
        private const string DataSource = "OBSERVER";

        private readonly OnBaseUnityModel _model;

        public OnBase(string userName, string password)
        {
            _model = new OnBaseUnityModel(ServiceURL, DataSource, userName, password.Secure());
        }

        public  List<DocumentType> GetDocumentTypes()
        {
            return _model.GetDocumentTypes();
        }

        public DocumentType GetDocumentType(string id)
        {
            return _model.GetDocumentType(id);
        }

        public IEnumerable<KeywordType> GetKeywordTypes()
        {
            return _model.GetKeywordTypes();
        }

        public KeywordType GetKeywordType(string id)
        {
            return _model.GetKeywordType(id);
        }

        public Document GetDocumnet(string id)
        {
            return _model.GetDocument(id);
        }

        public Stream GetFileData(string documentId)
        {
            return _model.GetFileData(documentId);
        }

        public Keywords GetKeywords(string documentId)
        {
            return _model.GetKeywords(documentId);
        }

        public List<Document> GetDocuments(string compassNumber)
        {
            return _model.GetDocuments(compassNumber);
        }

        public DocumentMetaData GetDocumentMetaData(long documentId)
        {
            return _model.GetDocumentMetaData(documentId);
        }

        public string CreateDocument(CreateDocumentParms parms)
        {
            return _model.CreateDocument(parms);
        }
    }
}
