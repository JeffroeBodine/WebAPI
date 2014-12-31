using System.Data.SqlClient;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Event;

namespace DataAccess
{
    public static class SessionFactoryManager
    {
        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2012.ConnectionString(LocalConnectionString))
                //.Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString))
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CaseMap>())
              .BuildSessionFactory();
        }

        private static string ConnectionString
        {
            get
            {
                var csb = new SqlConnectionStringBuilder
                {
                    DataSource = @"vm-qatrunk-2012",
                    InitialCatalog = "CompassFrameworkG3OB13",
                    UserID = "sa",
                    Password = "northwoods",
                    PersistSecurityInfo = false
                };

                return csb.ToString();
            }
        }

        private static string LocalConnectionString
        {
            get
            {
                var csb = new SqlConnectionStringBuilder
                {
                    DataSource = @".",
                    InitialCatalog = "webAPI",
                    UserID = "sa",
                    Password = "northwoods",
                    PersistSecurityInfo = false
                };

                return csb.ToString();
            }
        }
    }
}