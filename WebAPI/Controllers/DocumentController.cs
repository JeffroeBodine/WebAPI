
using System;
using System.Collections.Generic;
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

        public IHttpActionResult Add([FromBody] CreateDocumentParms parms)
        {
            var dms = new OnBase("jturner", "jturner");
            var id = dms.CreateDocument(parms);

            var uri = new Uri(Request.RequestUri, id);
            return Created(uri, id);
        }


    }
}
