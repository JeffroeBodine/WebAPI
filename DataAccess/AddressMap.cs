using FluentNHibernate.Mapping;
using ObjectLibrary;

namespace DataAccess
{
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Table("CPClientAddress");
            Id(x => x.Id).Column("pkCPClientAddress");

            Map(x => x.AddressType).Column("AddressType");

            Map(x => x.Street1).Column("Street1");
            Map(x => x.Street2).Column("Street2");
            Map(x => x.Street3).Column("Street3");

            Map(x => x.City).Column("City");
            Map(x => x.State).Column("State");
            Map(x => x.Zip).Column("Zip");
            Map(x => x.Plus4).Column("ZipPlus4");
        }
    }
}
