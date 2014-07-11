
using System.Web.Http;
using DMSPlugins.OnBase13;
using ObjectLibrary;

namespace WebAPI.Controllers
{
    public class DocumentController : ApiController
    {
        /// <summary>
        /// Returns a specific Document given an ID.
        /// </summary>
        public Document Get(string id)
        {
            var dms = new OnBase("jturner", "jturner");
            return dms.GetDocumnet(id);
        }
    }
}
