using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using ObjectLibrary;
using WebAPI;
namespace WebApi.Controllers
{
    public class TaskController : ControllerBase
    {
        public TaskController()
        {
            Repository = new ClientRepository();
        }

        public IEnumerable<Task> Get()
        {
            var tasks = Repository.Get<Task>();

            return tasks;
        }

        public Task Get(string id)
        {
            var task =Repository.Get<Task>(long.Parse(id));
            return task;
        }
    }
}