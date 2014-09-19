using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
            var putDocumentMetaData = new PutDocumentMetaData("tif", "image/tiff", 2, "2pgColor");

            //var fs = new FileStream("images/2pgColor.tif", FileMode.Open, FileAccess.Read);
            //var fs2 = new FileStream("images/2pgColor2.tif", FileMode.Open, FileAccess.Read);

            var multipartContent = new MultipartFormDataContent();

            var searlizedPutDocumentMetadata = JsonConvert.SerializeObject(putDocumentMetaData, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            multipartContent.Add(new StringContent(searlizedPutDocumentMetadata, Encoding.UTF8, "application/json"), "PutDocumentMetaData");

            int counter = 1;
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

     

        //private static Keyword CreateKeyword(KeywordTypes keywordType, string keywordValue)
        //{
        //    return new Keyword(new KeywordType((long)keywordType, keywordType.ToString(), typeof(string), ""), keywordValue) { DateTimeValue = DateTime.Now };
        //}
    }



}
