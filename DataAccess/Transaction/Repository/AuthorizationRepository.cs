using System.Linq;
using Common.DataAccess;
using Domain.Transaction;
using Domain.Transaction.Repository;
using NHibernate.Linq;

namespace DataAccess.Transaction.Repository
{
    public class AuthorizationRepository : RepositoryBase, IAuthorizationRepository
    {
        public AuthorizationRepository(ISimpleUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Authorization GetAuthorization(string transactionId)
        {
            var authorization = UnitOfWork
                .Session
                .Query<Authorization>()
                .SingleOrDefault(x => x.TransactionId == transactionId);

            return authorization;
        }
    }
}