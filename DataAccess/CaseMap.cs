    using FluentNHibernate.Mapping;
    using ObjectLibrary;

namespace DataAccess
{
    public class CaseMap : ClassMap<Case>
    {
        public CaseMap()
        {
            Table("CPClientCase");
            Id(x => x.ID).Column("pkCPClientCase");
            Map(x => x.CaseNumber).Column("StateCaseNumber");
            Map(x => x.SecondaryCaseNumber).Column("LocalCaseNumber");
            Map(x => x.CaseWorkerId).Column("fkApplicationUser");
            Map(x => x.CaseHeadId).Column("fkCPClientCaseHead");
            References(x => x.ProgramType, "fkCPRefClientCaseProgramType").Not.LazyLoad();
        }
    }
}
