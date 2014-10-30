using FluentNHibernate.Mapping;
using ObjectLibrary;

namespace DataAccess
{
    public class TaskMap : ClassMap<Task>
    {
        public TaskMap()
        {
            Table("Task");
            Id(x => x.Id).Column("pkTask");
            Map(x => x.Description).Column("Description");
            Map(x => x.Note).Column("Note");
            Map(x => x.DueDate).Column("DueDate");
            Map(x => x.StartDate).Column("StartDate");
            Map(x => x.EndDate).Column("CompleteDate");
            Map(x => x.GroupTask).Column("GroupTask");
            Map(x => x.Priority).CustomType<int>();

            References(x => x.Type, "fkRefTaskType").Not.LazyLoad();
            References(x => x.Status, "fkRefTaskStatus").Not.LazyLoad();
            References(x => x.Origin, "fkRefTaskOrigin").Not.LazyLoad().NotFound.Ignore();
        }
    }
}
