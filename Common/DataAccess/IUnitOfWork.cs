using System;
using NHibernate;

namespace Common.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        event UnitOfWorkNotifyEventHandler OnCommitted;

        event UnitOfWorkNotifyEventHandler OnRolledBack;

        bool IsRoot { get; }

        void Commit();

        void Rollback();

        ISession Session { get; }
    }
}