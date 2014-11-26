using System.Collections.Generic;
using DataAccess;
using ObjectLibrary.Connect;

namespace WebAPI.Controllers
{
    public class ConnectTypeController : ControllerBase
    {
        public ConnectTypeController()
        {
            Repository = new RepositoryBase();
        }

        public ConnectType Get(string id)
        {
            return Repository.Get<ConnectType>(long.Parse(id));
        }

        public List<ConnectType> Get()
        {
            return Repository.Get<ConnectType>();
        }
    }
}
