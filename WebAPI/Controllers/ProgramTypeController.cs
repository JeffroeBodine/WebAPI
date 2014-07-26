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
                var c =  rb.Get<Case>(long.Parse(id));

                return rb.Get<ProgramType>(c.ProgramTypeId);
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
