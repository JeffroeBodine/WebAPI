using FluentNHibernate.Mapping;
using ObjectLibrary;

namespace DataAccess
{
    public class TaskTypeMap : ClassMap<TaskType>
    {
        public TaskTypeMap()
        {
            Table("RefTaskType");
            Id(x => x.Id).Column("pkRefTaskType");
            Map(x => x.Name).Column("Description");

            Map(x => x.DefaultDueMinutes).Column("DefaultDueMinutes");
            Map(x => x.DefaultGroupTask).Column("DefaultGroupTask");
            Map(x => x.DefaultPriority).Column("DefaultPriority").CustomType<TaskPriority>();
            //Map(x => x.DueDateCalculation).Column("DueDateCalculation");
        }
    }
}
