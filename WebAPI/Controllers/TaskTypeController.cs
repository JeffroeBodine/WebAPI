using System.Collections.Generic;
using DataAccess;
using ObjectLibrary;
using WebAPI;
namespace WebAPI.Controllers
{
    public class TaskTypeController : ControllerBase
    {
        public TaskTypeController()
        {
            Repository = new ClientRepository();
        }

        public IEnumerable<TaskType> Get()
        {
            var taskTypes = Repository.Get<TaskType>();

            return taskTypes;
        }
    }
}