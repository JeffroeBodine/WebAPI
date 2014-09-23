using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using DataAccess;
using ObjectLibrary;

namespace WebAPI.Controllers
{
    public class CaseController : ControllerBase
    {
        public CaseController()
        {
            Repository = new ClientRepository();
        }

        [ActionName("Get")]
        public Case Get(string id)
        {
            return Repository.Get<Case>(long.Parse(id));
        }

        [HttpGet]
        //[ActionName("Client")]
        public List<Client> Client(string id)
        {
            return Repository.Get<Client>(GetSQLQueryForClientsInCase(id));
        }

        public IHttpActionResult Add([FromBody]Case value)
        {
            var id = Repository.Add(value);
            var uri = new Uri(Request.RequestUri, id);
            return Created(uri, id);
        }

        public IHttpActionResult Add(string id, [FromBody]Client client)
        {
            var clientId = Repository.Add(client);

            Repository.InsertJoinClientCase(long.Parse(id), long.Parse(clientId));

            var baseUri = new Uri("http://" + Request.Headers.Host + "/compassdatabroker/api/client/");
            var uri = new Uri(baseUri, clientId);

            return Created(uri, clientId);
        }

        private static string GetSQLQueryForClientsInCase(string caseId)
        {
            var sb = new StringBuilder();
            sb.AppendLine("select");
            sb.AppendLine("c.pkCPClient");
            sb.AppendLine(",c.NorthwoodsNumber");
            sb.AppendLine(",c.SSN");
            sb.AppendLine(",c.Suffix");
            sb.AppendLine(",c.FirstName");
            sb.AppendLine(",c.MiddleName");
            sb.AppendLine(",c.LastName");
            sb.AppendLine(",c.MaidenName");
            sb.AppendLine(",c.StateIssuedNumber");
            sb.AppendLine(",c.SISNumber");
            sb.AppendLine(",c.BirthDate");
            sb.AppendLine(",c.BirthLocation");
            sb.AppendLine(",c.Sex");
            sb.AppendLine(",c.HomePhone");
            sb.AppendLine(",c.CellPhone");
            sb.AppendLine(",c.WorkPhone");
            sb.AppendLine("from cpclient c");
            sb.AppendLine("inner join CPJoinClientClientCase j");
            sb.AppendLine("on j.fkCPClient = c.pkCPClient");
            sb.AppendLine("where j.fkCPClientCase = ").Append(caseId);

            return sb.ToString();
        }
    }
}
