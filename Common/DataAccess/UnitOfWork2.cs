using System;
using System.Data;
using NHibernate;

namespace Common.DataAccess
{
    public class UnitOfWork2 : IUnitOfWork2
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IsolationLevel _isolationLevel;

        public UnitOfWork2(ISessionFactory sessionFactory, IsolationLevel isolationLevel)
        {
            _sessionFactory = sessionFactory;
            _isolationLevel = isolationLevel;
        }

        public ISession Session { get; private set; }

        public void OpenSession()
        {
            
        }

        public void Commit()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Session != null)
                {
                    Session.Transaction.Dispose();
                    Session.Dispose();
                    Session = null;
                }
            }
        }
    }
}