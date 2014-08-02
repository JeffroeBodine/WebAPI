using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using ObjectLibrary;

namespace WebAPI.Controllers
{
    public class ClientController : ControllerBase
    {
        public List<Client> Get(string id)
        {
            return Repository.Get<Client>(GetSQLQuery(id));
        }

        public IHttpActionResult Add([FromBody]Client client)
        {
            var id = Repository.Add(client);
         
            var compassNumber = Repository.GetCompassNumber(client.ID);

            client.CompassNumber = compassNumber;

            Repository.Update(client);

            var uri = new Uri(Request.RequestUri, id);
            return Created(uri, client);
        }

        private static string GetSQLQuery(string caseId)
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
