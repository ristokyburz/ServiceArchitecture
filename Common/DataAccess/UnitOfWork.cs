using System;
using NHibernate;

namespace Common.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
		private bool _isHandled;

		public event UnitOfWorkNotifyEventHandler OnCommitted;

		public event UnitOfWorkNotifyEventHandler OnRolledBack;

		public UnitOfWork(ISession session, bool isRoot)
		{
			Session = session;
			IsRoot = isRoot;
		}

		public ISession Session { get; private set; }

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public bool IsRoot { get; private set; }

		public void Commit()
		{
			if (_isHandled)
			{
				const string message = "Commit was called after commit or rollback was called before.";
				throw new Exception(message);
			}

			Notify(OnCommitted);
		}

		public void Rollback()
		{
			Notify(OnRolledBack);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && !_isHandled)
			{
				Rollback();
			}
		}

		private void Notify(UnitOfWorkNotifyEventHandler notifyEvent)
		{
			notifyEvent(this);
			_isHandled = true;
		}

		~UnitOfWork()
		{
			Dispose(false);
		}
    }
}