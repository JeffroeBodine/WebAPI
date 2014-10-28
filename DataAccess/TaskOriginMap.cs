using FluentNHibernate.Mapping;
using ObjectLibrary;

namespace DataAccess
{
    public class TaskOriginMap : ClassMap<TaskOrigin>
    {
        public TaskOriginMap()
        {
            Table("refTaskOrigin");
            Id(x => x.Id).Column("pkRefTaskOrigin");
            Map(x => x.Name).Column("TaskOriginName");
            Map(x => x.Active).Column("Active");
        }
    }
}
