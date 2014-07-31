using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using DMSPlugins.OnBase13;

namespace WebAPI.Controllers
{
    public class FileController : ApiController
    {
        /// <summary>
        /// Returns a stream of data containing the file by the documentId.
        /// </summary>
        public HttpResponseMessage Get(string documentid)
        {
            var dms = new OnBase("jturner", "jturner");
            var stream = dms.GetFileData(documentid);
            var result = new HttpResponseMessage(HttpStatusCode.OK) {Content = new StreamContent(stream)};
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            var len = stream.Length;
            return result;
        }
    }
}
