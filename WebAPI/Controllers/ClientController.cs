using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using ObjectLibrary;

namespace WebAPI.Controllers
{
    public class ClientController : ControllerBase
    {

         public Client Get(string id)
        {
             return Repository.Get<Client>(long.Parse(id));
        }

        public IHttpActionResult Add([FromBody] Client client)
        {
            var id = Repository.Add(client);

            var compassNumber = Repository.GetCompassNumber(client.Id);

            client.CompassNumber = compassNumber;

            Repository.Update(client);

            var uri = new Uri(Request.RequestUri, id);
            return Created(uri, id);
        }

        public IHttpActionResult AddClientWithCase(string id, [FromBody] Client client)
        {
            var clientId = Repository.Add(client);

            //var clientCase = Repository.Get<Case>(long.Parse(caseId));
            //client.Cases = new List<Case>(){clientCase};

            var compassNumber = Repository.GetCompassNumber(client.Id);

            client.CompassNumber = compassNumber;

            Repository.Update(client);

            var uri = new Uri(Request.RequestUri, clientId);
            return Created(uri, client);
        }

    }
}
