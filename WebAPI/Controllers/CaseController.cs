using System.Web.Http;
using ObjectLibrary;
using DataAccess;

namespace WebAPI.Controllers
{
    public class CaseController : ApiController
    {
        public Case Get(string id)
        {
            using (var rb = new RepositoryBase())
            {
                return rb.Get<Case>(long.Parse(id));
            }
        }
    }
}
