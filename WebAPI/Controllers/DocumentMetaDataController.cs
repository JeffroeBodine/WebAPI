using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
