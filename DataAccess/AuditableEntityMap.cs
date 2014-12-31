using FluentNHibernate.Mapping;
using ObjectLibrary;

namespace DataAccess
{
    public class AuditableEntityMap<T> : ClassMap<T> where T : AuditableBaseObject<T>
    {
        public AuditableEntityMap()
        {
            Map(x => x.AuditUser).Column("AuditUser");
            Map(x => x.ModifiedUser).Column("ModifiedUser");

            Map(x => x.AuditDate).Column("AuditDate").CustomType("datetime2");
            Map(x => x.ModifiedDate).Column("ModifiedDate").CustomType("datetime2");

            Map(x => x.IPAddress).Column("IPAddress");
            Map(x => x.MACAddress).Column("MACAddress");
        }
    }
}
