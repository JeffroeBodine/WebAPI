using System.Collections.Generic;
using System.Web.Http;
using DMSPlugins.OnBase13;
using ObjectLibrary;

namespace WebAPI.Controllers
{
    public class KeywordTypeController : ApiController
    {
        /// <summary>
        /// Returns the collection of KeywordTypes.
        /// </summary>
        public IEnumerable<KeywordType> Get()
        {
            var dms = new OnBase("jturner", "jturner");
            return dms.GetKeywordTypes();
        }

        /// <summary>
        /// Returns a specific KeywordType given an ID.
        /// </summary>
        public KeywordType Get(string id)
        {
            var dms = new OnBase("jturner", "jturner");
            return dms.GetKeywordType(id);
        }
    }
}