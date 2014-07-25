﻿using NHibernate;
using NHibernate.Cfg;

namespace DataAccess
{
    public static class SessionFactoryManager
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();

                    configuration.Configure();
                    configuration.AddAssembly("NHibernateTest.Types");

                    _sessionFactory = configuration.BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}