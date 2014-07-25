using System.Data.SqlClient;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace DataAccess
{
    public static class SessionFactoryManager
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConnectionString))
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CaseMap>())
              .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
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
    }
}