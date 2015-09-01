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
            IUnitOfWorkFactory unitOfWorkFactory,
            TransactionTransfer.Factory transactionTransferFactory)
            : base(unitOfWorkFactory)
        {
            _transactionTransferFactory = transactionTransferFactory;
        }

        public TransactionTransfer GetTransactionTransfer(string transactionId)
        {
            using (var unitOfWork = UnitOfWorkFactory.UnitOfWork())
            {
                var captureTransfer = unitOfWork
                    .Session
                    .Query<CaptureTransfer>()
                    .SingleOrDefault(x => x.TransactionId == transactionId);

                var chargeTransfer = unitOfWork
                    .Session
                    .Query<ChargeTransfer>()
                    .SingleOrDefault(x => x.TransactionId == transactionId);

                unitOfWork.Commit();

                return _transactionTransferFactory(transactionId, captureTransfer, chargeTransfer);
            }
        }

        public void Save(TransactionTransfer transactionTransfer)
        {
            Save(transactionTransfer.CaptureTransfer);
            Save(transactionTransfer.ChargeTransfer);
        }
    }
}