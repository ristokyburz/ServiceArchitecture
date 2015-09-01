using System.Linq;
using Common.DataAccess;
using Domain.Transaction;
using Domain.Transaction.Repository;
using NHibernate.Linq;

namespace DataAccess.Transaction.Repository
{
    public class AuthorizationRepository : RepositoryBase, IAuthorizationRepository
    {
        public AuthorizationRepository(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }

        public Authorization GetAuthorization(string transactionId)
        {
            using (var unitOfWork = UnitOfWorkFactory.UnitOfWork())
            {
                var authorization = unitOfWork
                    .Session
                    .Query<Authorization>()
                    .SingleOrDefault(x => x.TransactionId == transactionId);

                unitOfWork.Commit();

                return authorization;
            }
        }
    }
}