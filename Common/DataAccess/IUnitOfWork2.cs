using System;
using NHibernate;

namespace Common.DataAccess
{
    public interface IUnitOfWork2 : IDisposable
    {
        ISession Session { get; }

        void OpenSession();

        void Commit();
    }
}