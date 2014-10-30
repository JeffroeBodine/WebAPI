using System;
using ObjectLibrary;

namespace DataAccess
{
   public class TaskRepository : RepositoryBase
    {
       public override string Add<T>(T obj)
       {
           var task = obj as Task;
           task.FixDates();

           if (task == null)
               throw new NullReferenceException("task");

           var id = base.Add(task);
           
           return id;
       }
    }
}
