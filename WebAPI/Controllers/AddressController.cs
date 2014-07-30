using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using DataAccess;
using ObjectLibrary;

namespace WebAPI.Controllers
{
    public class AddressController : ApiController
    {
        public List<Address> Get(string clientId)
        {
            using (var rb = new RepositoryBase())
            {
                return rb.Get<Address>(GetSQLQuery(clientId));
            }
        }

        private static string GetSQLQuery(string clientId)
        {
            var sb = new StringBuilder();

            sb.AppendLine("select");
            sb.AppendLine("a.pkCPClientAddress");
            sb.AppendLine(",AddressType = CASE WHEN a.fkCPRefClientAddressType = 1 THEN");
            sb.AppendLine("	'Home'");
            sb.AppendLine("Else");
            sb.AppendLine("	'Work'");
            sb.AppendLine("END");
            sb.AppendLine(",a.Street1");
            sb.AppendLine(",a.Street2");
            sb.AppendLine(",a.Street3");
            sb.AppendLine(",a.City");
            sb.AppendLine(",a.State");
            sb.AppendLine(",a.Zip");
            sb.AppendLine(",a.ZipPlus4");
            sb.AppendLine("from cpclientaddress a");
            sb.AppendLine("inner join CPJoinClientClientAddress j");
            sb.AppendLine("on j.fkCPClientAddress = a.pkCPClientAddress");
            sb.Append("where j.fkCPClient = ").AppendLine(clientId);

            return sb.ToString();
        }

    }
}
