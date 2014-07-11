using System.Collections.Generic;
using System.Web.Http;
using DMSPlugins.OnBase13;
using ObjectLibrary;

namespace WebAPI.Controllers
{
    public class DocumentTypeController : ApiController
    {
        /// <summary>
        /// Returns the collection of DocumentTypes.
        /// </summary>
        public IEnumerable<DocumentType> Get()
        {
            var dms = new OnBase("jturner", "jturner");
            return dms.GetDocumentTypes();
        }

        /// <summary>
        /// Returns a specific DocumentType given an ID.
        /// </summary>
        public DocumentType Get(string id)
        {
            var dms = new OnBase("jturner", "jturner");
            return dms.GetDocumentType(id);
        }
    }
}