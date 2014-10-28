using System.Collections.Generic;
using DataAccess;
using ObjectLibrary;
using WebAPI;
namespace WebApi.Controllers
{
    public class TaskStatusController : ControllerBase
    {
        public TaskStatusController()
        {
            Repository = new ClientRepository();
        }

        public IEnumerable<TaskStatus> Get()
        {
            var taskStatuses = Repository.Get<TaskStatus>();
            return taskStatuses;
        }
    }
}