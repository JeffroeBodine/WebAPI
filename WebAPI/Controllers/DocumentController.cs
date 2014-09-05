using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using DMSPlugins.OnBase13;
using DataAccess;
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

        //public IHttpActionResult Add([FromBody] CreateDocumentParms parms)
        //{
        //    var dms = new OnBase("jturner", "jturner");
        //    var id = dms.CreateDocument(parms);

        //    var uri = new Uri(Request.RequestUri, id);
        //    return Created(uri, id);
        //}

        public IHttpActionResult Add(ImageSet model)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("Received image set {0}: ", model.Name);
            model.Images.ForEach(i =>
                sb.AppendFormat("Got image {0} of type {1} and size {2} bytes,",
                    i.FileName,
                    i.MimeType,
                    i.ImageData.Length)
                );

            var result = sb.ToString();
            Trace.Write(result);

            return Ok(result);

            return null;
        }

    }


    public class ImageSet
    {
        public string Name { get; set; }

        public List<Image> Images { get; set; }
    }

    public class Image
    {
        public string FileName { get; set; }

        public string MimeType { get; set; }

        public byte[] ImageData { get; set; }
    }


    public class ImageSetMediaTypeFormatter : MediaTypeFormatter
    {
        public ImageSetMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(ImageSet);
        }

        public override bool CanWriteType(Type type)
        {
            return false;
        }

        public async override Task<object> ReadFromStreamAsync(
            Type type,
            Stream readStream,
            HttpContent content,
            IFormatterLogger formatterLogger)
        {
            var provider = await content.ReadAsMultipartAsync();

            var modelContent = provider.Contents
                .FirstOrDefault(c => c.Headers.ContentDisposition.Name.NormalizeName() == "imageset");

            var imageSet = await modelContent.ReadAsAsync<ImageSet>();

            var fileContents = provider.Contents
                .Where(c => c.Headers.ContentDisposition.Name.NormalizeName().Matches(@"image\d+"))
                .ToList();

            imageSet.Images = new List<Image>();
            foreach (var fileContent in fileContents)
            {
                imageSet.Images.Add(new Image
                {
                    ImageData = await fileContent.ReadAsByteArrayAsync(),
                    MimeType = fileContent.Headers.ContentType.MediaType,
                    FileName = fileContent.Headers.ContentDisposition.FileName.NormalizeName()
                });
            }

            return imageSet;

        }
    }

    public static class StringExtenstions
    {
        public static string NormalizeName(this string text)
        {
            return text.Replace("\"", "");
        }

        public static bool Matches(this string text, string pattern)
        {
            return Regex.IsMatch(text, pattern);
        }
    }
}