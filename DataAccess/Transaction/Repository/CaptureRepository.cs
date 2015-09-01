using System.Linq;
using Common.DataAccess;
using Domain.Transaction;
using Domain.Transaction.Repository;
using NHibernate.Linq;

namespace DataAccess.Transaction.Repository
{
    public class CaptureRepository : RepositoryBase, ICaptureRepository
    {
        public CaptureRepository(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }

        public Capture GetCapture(string transactionId)
        {
            using (var unitOfWork = UnitOfWorkFactory.UnitOfWork())
            {
                var capture = unitOfWork
                    .Session
                    .Query<Capture>()
                    .SingleOrDefault(x => x.TransactionId == transactionId);

                unitOfWork.Commit();

                return capture;
            }
        }
    }
}