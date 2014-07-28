using System.Web.Http;
using DataAccess;
using ObjectLibrary;

namespace WebAPI.Controllers
{
    public class ClientController : ApiController
    {
        public Client Get(string id)
        {
            using (var rb = new RepositoryBase())
            {
                return rb.Get<Client>(long.Parse(id));
            }
        }

    }
}
