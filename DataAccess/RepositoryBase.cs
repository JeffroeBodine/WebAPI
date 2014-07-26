﻿using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace DataAccess
{
    public class RepositoryBase : IDisposable
    {
        protected ISession Session = null;
        protected ITransaction Transaction = null;

        public RepositoryBase()
        {
            Session = SessionFactoryManager.CreateSessionFactory().OpenSession();
        }

        public RepositoryBase(ISession session)
        {
            Session = session;
        }

        public virtual T Get<T>(long id)
        {
            return Session.Get<T>(id);
        }

        public virtual List<T> Get<T>()
        {
            return Session.Query<T>().ToList();
        }

        public virtual T Add<T>(T obj)
        {
            BeginTransaction();
            return (T)Session.Save(obj);
        }

        public virtual T Update<T>(T obj)
        {
            BeginTransaction();
            Session.Update(obj);
            return obj;
        }

        public virtual T Delete<T>(T obj)
        {
            BeginTransaction();
            var existingObject = Session.Query<T>().FirstOrDefault(x => x.Equals(obj));

            if (existingObject != null)
                Session.Delete(existingObject);

            return obj;
        }

        #region Transaction and Session Management Methods

        private void BeginTransaction()
        {
            Transaction = Session.BeginTransaction();
        }

        private void CommitTransaction()
        {
            // _transaction will be replaced with a new transaction
            // by NHibernate, but we will close to keep a consistent state.
            Transaction.Commit();

            CloseTransaction();
        }

        private void RollbackTransaction()
        {
            // _session must be closed and disposed after a transaction
            // rollback to keep a consistent state.
            Transaction.Rollback();

            CloseTransaction();
            CloseSession();
        }

        private void CloseTransaction()
        {
            Transaction.Dispose();
            Transaction = null;
        }

        private void CloseSession()
        {
            Session.Close();
            Session.Dispose();
            Session = null;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (Transaction != null)
            {
                CommitTransaction();
            }

            if (Session != null)
            {
                Session.Flush();
                CloseSession();
            }
        }

        #endregion
    }
}