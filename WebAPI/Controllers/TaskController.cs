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
            var tasks = Repository.Get<Task>(GetSQLQuery());

            return tasks;
        }

        public Task Get(string id)
        {
            return Repository.Get<Task>(long.Parse(id));
        }


        private static string GetSQLQuery()
        {
            var sb = new StringBuilder();

            sb.AppendLine("select");
            sb.AppendLine("pkTask,");
            sb.AppendLine("Description,");
            sb.AppendLine("Note,");
            sb.AppendLine("DueDate,");
            sb.AppendLine("StartDate,");
            sb.AppendLine("CompleteDate,");
            sb.AppendLine("GroupTask");
            sb.AppendLine("from Task");

            return sb.ToString();
        }
    }
}