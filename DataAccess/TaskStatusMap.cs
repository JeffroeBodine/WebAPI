using FluentNHibernate.Mapping;
using ObjectLibrary;

namespace DataAccess
{
    public class TaskStatusMap : ClassMap<TaskStatus>
    {
        public TaskStatusMap()
        {
            Table("refTaskStatus");
            Id(x => x.Id).Column("pkRefTaskStatus");
            Map(x => x.Description).Column("Description");
        }
    }
}
