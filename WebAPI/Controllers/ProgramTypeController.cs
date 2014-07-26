using System.Collections.Generic;
using System.Web.Http;
using ObjectLibrary;
using DataAccess;

namespace WebAPI.Controllers
{
    public class ProgramTypeController : ApiController
    {
        public ProgramType Get(string id)
        {
            using (var rb = new RepositoryBase())
            {
                return rb.Get<ProgramType>(long.Parse(id));
            }
        }

        public List<ProgramType> Get()
        {
            using (var rb = new RepositoryBase())
            {
                return rb.Get<ProgramType>();
            }
        }
    }
}
