using NHibernate;

namespace Common.DataAccess
{
	public class SimpleUnitOfWork : ISimpleUnitOfWork
	{
		private readonly ISessionFactory _sessionFactory;
		private ISession _lifeTimeSession;

		public SimpleUnitOfWork(ISessionFactory sessionFactory)
		{
			_sessionFactory = sessionFactory;
		}

		public ISession Session
		{
			get
			{
				if (_lifeTimeSession == null)
				{
					_lifeTimeSession = _sessionFactory.OpenSession();
				}

				return _lifeTimeSession;
			}
		}

		public ISession GetNewSession()
		{
			return _sessionFactory.OpenSession();
		}
	}
}