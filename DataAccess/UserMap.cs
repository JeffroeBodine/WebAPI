using FluentNHibernate.Mapping;
using ObjectLibrary;

namespace DataAccess
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Identity();
            Map(x => x.UserName);
            Map(x => x.Password);
            Map(x => x.Salt);
            Map(x => x.EMail);
            Map(x => x.FirstName);
            Map(x => x.LastName);     
        }
    }
}
