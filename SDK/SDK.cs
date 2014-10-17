using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ObjectLibrary;

namespace WebApi
{
    public class SDK
    {
        public string BaseUrl { get; private set; }

        public SDK(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public IEnumerable<DocumentType> GetDocumentTypes()
        {
            return MakeRestCall<IEnumerable<DocumentType>>("DocumentType");
        }
        public DocumentType GetDocumentType(string id)
        {
            return MakeRestCall<DocumentType>(String.Format("DocumentType/{0}", id));
        }

        public IEnumerable<KeywordType> GetKeywordTypes()
        {
            return MakeRestCall<IEnumerable<KeywordType>>("KeywordType");
        }
        public KeywordType GetKeywordType(string id)
        {
            return MakeRestCall<KeywordType>(String.Format("KeywordType/{0}", id));
        }

        public Case GetCase(string id)
        {
            return MakeRestCall<Case>(String.Format("Case/{0}", id));
        }
        public IEnumerable<Client> GetClients(string caseId)
        {
            return MakeRestCall<IEnumerable<Client>>(String.Format("Case/{0}/Client", caseId));
        }

        public Client GetClient(string id)
        {
            return MakeRestCall<Client>(String.Format("Client/{0}", id));
        }

        public IEnumerable<Address> GetAddresses(string clientId)
        {
            return MakeRestCall<IEnumerable<Address>>(String.Format("Client/{0}/Address", clientId));
        }

        public IEnumerable<ProgramType> GetProgramTypes()
        {
            return MakeRestCall<IEnumerable<ProgramType>>("ProgramType");
        }

        public ProgramType GetProgramType(string id)
        {
            return MakeRestCall<ProgramType>(String.Format("ProgramType/{0}", id));
        }

        public IEnumerable<Document> GetDocuments(string clientId)
        {
            return MakeRestCall<IEnumerable<Document>>(String.Format("Client/{0}/Document", clientId));
        }

        public DocumentMetaData GetDocumentMetaData(string documentId)
        {
            return MakeRestCall<DocumentMetaData>(String.Format("Document/{0}/MetaData", documentId));
        }

        public IEnumerable<Keyword> GetKeywords(string documentId)
        {
            return MakeRestCall<IEnumerable<Keyword>>(String.Format("Document/{0}/Keyword", documentId));
        }

        public Stream GetFile(string documentId)
        {
            var methodName = String.Format("Document/{0}/File", documentId);
            var ms = new MemoryStream();

            using (var client = new HttpClient() {BaseAddress = new Uri(BaseUrl)})
            {
                var responseMessage = client.GetAsync(methodName).Result;

                if (responseMessage.IsSuccessStatusCode)
                {
                    using (var result = responseMessage.Content.ReadAsStreamAsync().Result)
                    {
                        result.CopyTo(ms);
                        ms.Position = 0;
                    }
                }
            }
            return ms;
        }
        
        private T MakeRestCall<T>(string methodName)
        {
            try
            {
                using (var client = new HttpClient() { BaseAddress = new Uri(BaseUrl) })
                {
                    var response = client.GetAsync(methodName).Result;
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsAsync<T>().Result;
                    }
                }
                return default(T);
            }
            catch (Exception ex)
            {
                int i = 0;
                //throw;
            }
            return default(T);
        }
    }
}
