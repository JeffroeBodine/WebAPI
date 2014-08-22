
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
        /// <summary>
        /// Returns a specific Document given an Id.
        /// </summary>
        //public Document Get(string id)
        //{
        //    var dms = new OnBase("jturner", "jturner");
        //    return dms.GetDocumnet(id);
        //}

        public List<Document> Get(string clientId)
        {
            //Get CompassNumber from Client

            string compassNumber;
            using (var rb = new RepositoryBase())
            {
                compassNumber = rb.Get<Client>(long.Parse(clientId)).CompassNumber;
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
