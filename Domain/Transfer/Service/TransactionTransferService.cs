using Common.DataAccess;
using Domain.Transfer.Repository;

namespace Domain.Transfer.Service
{
    public class TransactionTransferService : ITransactionTransferService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ITransactionTransferRepository _transactionTransferRepository;

        public TransactionTransferService(
            IUnitOfWorkFactory unitOfWorkFactory,
            ITransactionTransferRepository transactionTransferRepository)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _transactionTransferRepository = transactionTransferRepository;
        }


        public void TransferCapture(string transactionId)
        {
            using (var unitOfWork = _unitOfWorkFactory.UnitOfWork())
            {
                var transactionTransfer = _transactionTransferRepository.GetTransactionTransfer(transactionId);

                transactionTransfer.TransferCapture();

                _transactionTransferRepository.Save(transactionTransfer);

                unitOfWork.Commit();
            }
        }

        public void CompleteCaptureTransfer(string transactionId)
        {
            using (var unitOfWork = _unitOfWorkFactory.UnitOfWork())
            {
                var transactionTransfer = _transactionTransferRepository.GetTransactionTransfer(transactionId);

                transactionTransfer.CompleteCaptureTransfer();

                _transactionTransferRepository.Save(transactionTransfer);

                unitOfWork.Commit();                
            }
        }

        public void TransferCharge(string transactionId)
        {
            using (var unitOfWork = _unitOfWorkFactory.UnitOfWork())
            {
                var transactionTransfer = _transactionTransferRepository.GetTransactionTransfer(transactionId);

                transactionTransfer.TransferCharge();

                _transactionTransferRepository.Save(transactionTransfer);

                unitOfWork.Commit();
            }
        }

        public void CompleteChargeTransfer(string transactionId)
        {
            using (var unitOfWork = _unitOfWorkFactory.UnitOfWork())
            {
                var transactionTransfer = _transactionTransferRepository.GetTransactionTransfer(transactionId);

                transactionTransfer.CompleteChargeTransfer();

                _transactionTransferRepository.Save(transactionTransfer);

                unitOfWork.Commit();
            }
        }
    }
}