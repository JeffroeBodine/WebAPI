using FluentNHibernate.Mapping;
using ObjectLibrary;


namespace DataAccess
{
    public class CientMap : ClassMap<Client>
    {
        public CientMap()
        {
            Table("cpClient");
            Id(x => x.Id).Column("pkCPClient");

            Map(x => x.CompassNumber).Column("NorthwoodsNumber");
            Map(x => x.StateIssuedNumber).Column("StateIssuedNumber");
            Map(x => x.SISNumber).Column("SISNumber");
            Map(x => x.SSN).Column("SSN");

            Map(x => x.Suffix).Column("Suffix");
            Map(x => x.FirstName).Column("FirstName");
            Map(x => x.MiddleName).Column("MiddleName");
            Map(x => x.LastName).Column("LastName");
            Map(x => x.MaidenName).Column("MaidenName");

            Map(x => x.BirthDate).Column("BirthDate");
            Map(x => x.BirthLocation).Column("BirthLocation");
            Map(x => x.Gender).Column("Sex");

            Map(x => x.HomePhone).Column("HomePhone");
            Map(x => x.CellPhone).Column("CellPhone");
            Map(x => x.WorkPhone).Column("WorkPhone");

            //HasManyToMany(x => x.Cases)
            //   .Table("CPJoinClientClientCase").ParentKeyColumn("fkCPClient")
            //   .ChildKeyColumn("fkCPClientCase")
            //   .Fetch.Join();

           // HasManyToMany(x => x.Case)
           //.Cascade.All()
           //.Inverse()
           //.Not.LazyLoad()
           //.Table("cpjoinclientclientcase");

            

        }
    }
}