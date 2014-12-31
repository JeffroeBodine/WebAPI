using FluentNHibernate.Mapping;
using ObjectLibrary;

namespace DataAccess
{
    public class AuditableEntityMap<T> : ClassMap<T> where T : AuditableBaseObject<T>
    {
        public AuditableEntityMap()
        {
            Map(x => x.AuditUser).Column("AuditUser");
            Map(x => x.AuditApplication).Column("AuditApplication");
        }
    }
}
