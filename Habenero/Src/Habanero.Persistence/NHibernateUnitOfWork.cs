using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Habanero.Persistence
{
    public class NHibernateUnitOfWork : INHibernateUnitOfWork
    {
        private ITransaction _transaction;
        private ISession _session;
        private bool _disposed;
        private bool _begun;
        private  INHibernateSessionManager _nHibernateSessionManager;

        public NHibernateUnitOfWork(INHibernateSessionManager nHibernateSessionManager)
        {
            _nHibernateSessionManager = nHibernateSessionManager;
        }

        public ISession OpenSession()
        {
            _session = _nHibernateSessionManager.OpenSession();
            return _session;
        }

        public ISession Session
        {
            get { return _session; }
        }

        public void Begin()
        {
            CheckIsDisposed();

            if (_begun)
            {
                return;
            }

            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            _transaction = Session.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            _begun = true;
        }

        public void Commit()
        {
            CheckIsDisposed();
            CheckHasBegun();

            if (_transaction.IsActive && !_transaction.WasRolledBack)
            {
                _transaction.Commit();
            }

            _begun = false;
        }

        public void Rollback()
        {
            CheckIsDisposed();
            CheckHasBegun();

            if (_transaction.IsActive)
            {
                _transaction.Rollback();
                Session.Clear();
            }

            _begun = false;
        }

        public void Dispose()
        {
            if (!_begun || _disposed)
                return;

            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            if (Session != null)
            {
                Session.Dispose();
            }

            _disposed = true;
        }

        private void CheckHasBegun()
        {
            if (!_begun)
            {
                throw new InvalidOperationException("Must call Begin() on the unit of work before committing");
            }
        }

        private void CheckIsDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}
