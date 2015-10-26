using System.Linq;
using Common.DataAccess;
using Domain.Transaction;
using Domain.Transaction.Repository;
using NHibernate.Linq;

namespace DataAccess.Transaction.Repository
{
    public class CaptureRepository : RepositoryBase, ICaptureRepository
    {
        public CaptureRepository(ISimpleUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Capture GetCapture(string transactionId)
        {
            var capture = UnitOfWork
                .Session
                .Query<Capture>()
                .SingleOrDefault(x => x.TransactionId == transactionId);

            return capture;
        }
    }
}