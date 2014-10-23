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
            return Repository.Get<Task>(GetSQLQuery(""));
        }

        public Task Get(string id)
        {
            return Repository.Get<Task>(long.Parse(id));
        }


        private static string GetSQLQuery(string taskId)
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

            if (!string.IsNullOrEmpty(taskId))
            {
                sb.Append(String.Format("where pkTask = {0}", taskId));
            }
            return sb.ToString();
        }
    }
}