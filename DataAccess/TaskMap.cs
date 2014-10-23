using FluentNHibernate.Mapping;
using ObjectLibrary;

namespace DataAccess
{
    public class TaskMap : ClassMap<Task>
    {
        public TaskMap()
        {
            Table("Task");
            Id(x => x.Id).Column("PKtASK");
            Map(x => x.Description).Column("Description");
            Map(x => x.Note).Column("Note");
            Map(x => x.DueDate).Column("DueDate");
            Map(x => x.StartDate).Column("StartDate");
            Map(x => x.EndDate).Column("CompleteDate");
            Map(x => x.GroupTask).Column("GroupTask");
        }
    }
}
