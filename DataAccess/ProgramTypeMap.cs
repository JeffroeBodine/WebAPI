using FluentNHibernate.Mapping;
using ObjectLibrary;


namespace DataAccess
{
    public class ProgramTypeMap : ClassMap<ProgramType>
    {
        public ProgramTypeMap()
        {
            Table("ProgramType");
            Id(x => x.Id).Column("pkProgramType");
            Map(x => x.Name).Column("ProgramType");
        }
    }
}
