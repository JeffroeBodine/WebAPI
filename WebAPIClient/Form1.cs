using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ObjectLibrary;

namespace WebAPIClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SendImageSet();
        }

        private static void SendImageSet()
        {
            var putDocumentParams = new PutDocumentParams(337);

            var compassNumberKWT = new KeywordType(136, "", typeof (string), "");
            var SSNKWT = new KeywordType(103, "", typeof(string), "");
            var FirstNameKWT = new KeywordType(104, "", typeof(string), "");
            var LastNameKWT = new KeywordType(105, "", typeof(string), "");

            putDocumentParams.Keywords.Add(new Keyword(compassNumberKWT,"OH123000000001"));
            putDocumentParams.Keywords.Add(new Keyword(SSNKWT, "111-11-1111"));
            putDocumentParams.Keywords.Add(new Keyword(FirstNameKWT, "Jeffroe"));
            putDocumentParams.Keywords.Add(new Keyword(LastNameKWT, "Bodine"));

            var multipartContent = new MultipartFormDataContent();

            var searlizedPutDocumentMetadata = JsonConvert.SerializeObject(putDocumentParams, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            multipartContent.Add(new StringContent(searlizedPutDocumentMetadata, Encoding.UTF8, "application/json"), "PutDocumentParams");

            var counter = 1;
            foreach (var fileName in Directory.GetFiles("images"))
            {
                var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                multipartContent.Add(new StreamContent(fs), "File" + counter, Path.GetFileName(fileName));
                counter++;
            }

            var response = new HttpClient()
                .PostAsync("http://localhost/CompassDataBroker/api/Document/UploadFile", multipartContent)
                .Result;

            var responseContent = response.Content.ReadAsStringAsync().Result;
            Trace.Write(responseContent);
        }
    }
}
