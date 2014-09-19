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

            var fs = new FileStream("images/2pgColor.tif", FileMode.Open, FileAccess.Read);
            var fs2 = new FileStream("images/2pgColor2.tif", FileMode.Open, FileAccess.Read);

            var multipartContent = new MultipartFormDataContent();




            var searlizedPutDocumentMetadata = JsonConvert.SerializeObject(putDocumentMetaData, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

            multipartContent.Add(new StringContent(searlizedPutDocumentMetadata, Encoding.UTF8, "application/json"), "PutDocumentMetaData");
            multipartContent.Add(new StreamContent(fs), "File1","2pgColor.tif");
            multipartContent.Add(new StreamContent(fs2), "File2", "2pgColor2.tif");

            //int counter = 0;
            //foreach (var image in imageSet.Images)
            //{
             
            //    var imageContent = new ByteArrayContent(image.ImageData);
            //    imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.MimeType);
            //    multipartContent.Add(imageContent, "image" + counter++, image.FileName);
            //}

            var response = new HttpClient()
                .PostAsync("http://localhost/CompassDataBroker/api/Document/UploadFile", multipartContent)
                .Result;

            var responseContent = response.Content.ReadAsStringAsync().Result;
            Trace.Write(responseContent);
        }

        //static async void DoShit()
        //{
        //    var baseAddress = new Uri(@"http://localhost/CompassDataBroker/api/");

        //    using (var client = new HttpClient())
        //    {
        //        var parms = new CreateDocumentParms { DocumentTypeId = (long)DocumentTypes.JeffroesDocType };
        //        parms.Keywords.Add(CreateKeyword(KeywordTypes.FirstName, "Johnny"));
        //        parms.Keywords.Add(CreateKeyword(KeywordTypes.LastName, "Northwoods"));
        //        parms.Keywords.Add(CreateKeyword(KeywordTypes.SSN, "111-11-1111"));
        //        parms.Keywords.Add(CreateKeyword(KeywordTypes.CompassNumber, "OH123000000001"));

        //        client.BaseAddress = baseAddress;
        //        var response = await client.PostAsJsonAsync("Document", parms);
        //    }
        //}

        //private static Keyword CreateKeyword(KeywordTypes keywordType, string keywordValue)
        //{
        //    return new Keyword(new KeywordType((long)keywordType, keywordType.ToString(), typeof(string), ""), keywordValue) { DateTimeValue = DateTime.Now };
        //}
    }



}
