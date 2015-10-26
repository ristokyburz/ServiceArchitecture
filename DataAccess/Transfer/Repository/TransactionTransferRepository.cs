using System.Linq;
using Common.DataAccess;
using Domain.Transfer;
using Domain.Transfer.Repository;
using NHibernate.Linq;

namespace DataAccess.Transfer.Repository
{
    public class TransactionTransferRepository : RepositoryBase, ITransactionTransferRepository
    {
        private readonly TransactionTransfer.Factory _transactionTransferFactory;

        public TransactionTransferRepository(
            ISimpleUnitOfWork unitOfWork,
            TransactionTransfer.Factory transactionTransferFactory)
            : base(unitOfWork)
        {
            _transactionTransferFactory = transactionTransferFactory;
        }

        public TransactionTransfer GetTransactionTransfer(string transactionId)
        {
            var captureTransfer = UnitOfWork
                .Session
                .Query<CaptureTransfer>()
                .SingleOrDefault(x => x.TransactionId == transactionId);

			var chargeTransfer = UnitOfWork
                .Session
                .Query<ChargeTransfer>()
                .SingleOrDefault(x => x.TransactionId == transactionId);

            return _transactionTransferFactory(transactionId, captureTransfer, chargeTransfer);
        }

        public void Save(TransactionTransfer transactionTransfer)
        {
            Save(transactionTransfer.CaptureTransfer);
            Save(transactionTransfer.ChargeTransfer);
        }
    }
}