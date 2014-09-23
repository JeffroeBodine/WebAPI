using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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
            return  MakeRestCall<IEnumerable<DocumentType>>("DocumentType");
        }
        public DocumentType GetDocumentType(string id)
        {
            return MakeRestCall<DocumentType>(String.Format("DocumentType/{0}" , id));
        }

        public IEnumerable<KeywordType> GetKeywordTypes()
        {
               return  MakeRestCall<IEnumerable<KeywordType>>("KeywordType");
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

        private T MakeRestCall<T>(string methodName)
        {
            using (var client = new HttpClient(){BaseAddress = new Uri(BaseUrl)})
            {
                var response = client.GetAsync(methodName).Result;

                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsAsync<T>().Result;
            }
            return default(T);
        }
    }
}
