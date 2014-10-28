using System.Collections.Generic;
using System.Linq;
using DataAccess;
using ObjectLibrary;
using WebAPI;
namespace WebApi.Controllers
{
    public class TaskOriginController : ControllerBase
    {
        public TaskOriginController()
        {
            Repository = new ClientRepository();
        }

        public IEnumerable<TaskOrigin> Get()
        {
            var taskOrigins = Repository.Get<TaskOrigin>();
            return taskOrigins.Where(x=>x.Active);
        }
    }
}