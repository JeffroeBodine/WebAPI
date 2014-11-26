using FluentNHibernate.Mapping;
using ObjectLibrary;
using ObjectLibrary.Connect;

namespace DataAccess
{
    public class ConnectTypeMap : ClassMap<ConnectType>
    {
        public ConnectTypeMap()
        {
            Table("ConnectType");
            Id(x => x.Id).Column("pkConnectType");
            Map(x => x.Name).Column("Description");
            Map(x => x.Enabled).Column("EnableCloudSync");
            Map(x => x.Interval).Column("SyncInterval");
            Map(x => x.SyncProviderType).Column("SyncProviderType");

        }
    }
}
