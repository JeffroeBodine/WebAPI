using FluentNHibernate.Mapping;
using ObjectLibrary;

namespace DataAccess
{
    public class CaseMap : ClassMap<Case>
    {
        public CaseMap()
        {
            Table("CPClientCase");
            Id(x => x.Id).Column("pkCPClientCase");
            Map(x => x.CaseNumber).Column("StateCaseNumber");
            Map(x => x.SecondaryCaseNumber).Column("LocalCaseNumber");
            Map(x => x.ProgramTypeId).Column("fkCPRefClientCaseProgramType");
            Map(x => x.CaseWorkerId).Column("fkApplicationUser");
            Map(x => x.CaseHeadId).Column("fkCPClientCaseHead");

            //HasManyToMany(x => x.Clients)
            //.Table("CPJoinClientClientCase").ParentKeyColumn("fkCPClientCase")
            //.ChildKeyColumn("fkCPClient")
            //.LazyLoad();

           // HasManyToMany(x => x.Clients)
           //  .Cascade.All()
           //  .Not.LazyLoad()
           //   .ParentKeyColumn("fkCPClientCase")
           //.ChildKeyColumn("fkCPClient")
           //  .Table("cpjoinclientclientcase");

        }
    }
}
