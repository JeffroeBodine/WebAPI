using System.Web.Http;
using DMSPlugins.OnBase13;
using ObjectLibrary.Collections;

namespace WebAPI.Controllers
{
    public class KeywordController : ApiController
    {
        public Keywords Get(string id)
        {
            var dms = new OnBase("jturner", "jturner");
            return dms.GetKeywords(id);
        }
    }
}
