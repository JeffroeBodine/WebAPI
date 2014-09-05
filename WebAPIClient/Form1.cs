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

            var imageSet = new ImageSet()
            {
                Name = "Model",
                Images = Directory
                    .EnumerateFiles("../../../../../SampleImages")
                    .Where(file => new[] { ".jpg", ".png" }.Contains(Path.GetExtension(file)))
                    .Select(file => new Image
                    {
                        FileName = Path.GetFileName(file),
                        MimeType = MimeMapping.GetMimeMapping(file),
                        ImageData = File.ReadAllBytes(file)
                    })
                    .ToList()
            };

            SendImageSet(imageSet);

        }

        private static void SendImageSet(ImageSet imageSet)
        {
            var multipartContent = new MultipartFormDataContent();

            var imageSetJson = JsonConvert.SerializeObject(imageSet,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            multipartContent.Add(
                new StringContent(imageSetJson, Encoding.UTF8, "application/json"),
                "imageset"
                );

            int counter = 0;
            foreach (var image in imageSet.Images)
            {
                var imageContent = new ByteArrayContent(image.ImageData);
                imageContent.Headers.ContentType = new MediaTypeHeaderValue(image.MimeType);
                multipartContent.Add(imageContent, "image" + counter++, image.FileName);
            }

            var response = new HttpClient()
                .PostAsync("http://localhost:53908/api/send", multipartContent)
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

    public class ImageSet
    {
        public string Name { get; set; }

        [JsonIgnore]
        public List<Image> Images { get; set; }
    }

    public class Image
    {
        public string FileName { get; set; }

        public string MimeType { get; set; }

        public byte[] ImageData { get; set; }
    }

}
