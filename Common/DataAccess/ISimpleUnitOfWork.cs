using NHibernate;

namespace Common.DataAccess
{
	public interface ISimpleUnitOfWork
	{
		ISession Session { get; }

		ISession GetNewSession(); 
	}
}