using System.Web.Http;
using DMSPlugins.OnBase13;
using ObjectLibrary;

namespace WebAPI.Controllers
{
    public class DocumentMetaDataController : ApiController
    {
        public DocumentMetaData Get(string documentid)
        {
            var dms = new OnBase("jturner", "jturner");
            return dms.GetDocumentMetaData(long.Parse(documentid));
        }

    }
}
