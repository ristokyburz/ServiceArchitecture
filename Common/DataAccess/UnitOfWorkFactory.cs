using System;
using System.Data;
using NHibernate;

namespace Common.DataAccess
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private bool _wasSessionRolledBack;
        private ISession _session;
        private readonly ISessionFactory _sessionFactory;
        private readonly IsolationLevel _isolationLevel;

        public UnitOfWorkFactory(ISessionFactory sessionFactory, IsolationLevel isolationLevel)
        {
            _sessionFactory = sessionFactory;
            _isolationLevel = isolationLevel;
        }

        public IUnitOfWork UnitOfWork()
        {
            return InternalUnitOfWork();
        }

        private IUnitOfWork InternalUnitOfWork()
        {
            if (_wasSessionRolledBack)
            {
                string message = "Creating a new UnitOfWork failed because of a previous rollback!";
                message += " IsolationLevel: " + _isolationLevel;

                throw new Exception(message);
            }

            bool isRoot = false;
            if (_session == null)
            {
                _session = _sessionFactory.OpenSession();
                _session.Transaction.Begin(_isolationLevel);

                isRoot = true;
            }

            var uow = new UnitOfWork(_session, isRoot);
            uow.OnCommitted += OnCommitRequested;
            uow.OnRolledBack += OnRollbackRequested;

            return uow;
        }

        private void OnCommitRequested(IUnitOfWork unitOfWork)
        {
            if (_wasSessionRolledBack)
            {
                const string message = "Cannot commit because the session is already rolled back.";
                throw new Exception(message);
            }

            if (unitOfWork.IsRoot)
            {
                _session.Transaction.Commit();
                DisposeAndDeleteSession();
            }
        }

        private void OnRollbackRequested(IUnitOfWork unitOfWork)
        {
            if (!_wasSessionRolledBack && _session.Transaction.IsActive)
            {
                try
                {
                    _session.Transaction.Rollback();
                }
                catch (TransactionException)
                {
                    // ignore these exceptions as the transaction was already rolled back
                }

                _wasSessionRolledBack = true;
                DisposeAndDeleteSession();
            }
        }

        private void DisposeAndDeleteSession()
        {
            _session.Transaction.Dispose();
            _session.Dispose();
            _session = null;
        }
    }
}