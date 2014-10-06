using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using DMSPlugins.OnBase13;
using DataAccess;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ObjectLibrary;

namespace WebAPI.Controllers
{
    public class DocumentController : ApiController
    {
        public List<Document> Get(string id)
        {
            //Get CompassNumber from Client

            string compassNumber;
            using (var rb = new RepositoryBase())
            {
                compassNumber = rb.Get<Client>(long.Parse(id)).CompassNumber;
            }
            //Do a document search based on CompassNumber
            var dms = new OnBase("jturner", "jturner");
            return dms.GetDocuments(compassNumber);
        }

        [Route("UploadFile")]
        [HttpPost]
        [ValidateMimeMultipartContentFilter]
        public async Task<IHttpActionResult> Add(HttpRequestMessage request)
        {
            var root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
            await Request.Content.ReadAsMultipartAsync(provider);

            var transactionId = Guid.NewGuid().ToString();

            var filePaths = MoveFilesToTransactionFolder(provider, transactionId);

            var putDocumentParams = GetPutDocumentMetaDataFromProvider(provider);

            var dms = new OnBase("jturner", "jturner");
            var documentId = dms.CreateDocument(putDocumentParams, filePaths);

            var uri = new Uri(Request.RequestUri, documentId);
            return Created(uri, documentId);
        }

        private static PutDocumentParams GetPutDocumentMetaDataFromProvider(MultipartFormDataStreamProvider provider)
        {
            var putDocumentMetaDataKey = provider.FormData.AllKeys.Single(x => x == "PutDocumentParams");
            var putDocumentMetaDataString = provider.FormData.GetValues(putDocumentMetaDataKey).Single();

            return GetPutDocumentMetaDataFromString(putDocumentMetaDataString);
        }

        private static PutDocumentParams GetPutDocumentMetaDataFromString(string input)
        {
            PutDocumentParams parms;

            parms = JsonConvert.DeserializeObject<PutDocumentParams>
                (
                    input,
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }
                );

            return parms;


        }

        private static List<string> MoveFilesToTransactionFolder(MultipartFormDataStreamProvider provider, string transactionId)
        {
           var filePaths = new List<string>();
            foreach (var file in provider.FileData)
            {
                var correctFileName = file.Headers.ContentDisposition.FileName;
                correctFileName = correctFileName.StripIllegalFilePathCharacters();

                var tmpFolderPath = Path.GetDirectoryName(file.LocalFileName);
                var fileInfo = new FileInfo(file.LocalFileName);

                if (!Directory.Exists(Path.Combine(tmpFolderPath, transactionId)))
                {
                    Directory.CreateDirectory(Path.Combine(tmpFolderPath, transactionId));
                }

                fileInfo.MoveTo(Path.Combine(tmpFolderPath, transactionId, correctFileName));

                filePaths.Add(Path.Combine(tmpFolderPath, transactionId, correctFileName));
            }
            return filePaths;
        }
    }

}