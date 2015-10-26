using Domain.Transfer.Repository;

namespace Domain.Transfer.Service
{
    public class TransactionTransferService : ITransactionTransferService
    {
	    private readonly ITransactionTransferRepository _transactionTransferRepository;

        public TransactionTransferService(
            ITransactionTransferRepository transactionTransferRepository)
        {
	        _transactionTransferRepository = transactionTransferRepository;
        }


        public void TransferCapture(string transactionId)
        {
            var transactionTransfer = _transactionTransferRepository.GetTransactionTransfer(transactionId);
            transactionTransfer.TransferCapture();
            _transactionTransferRepository.Save(transactionTransfer);
        }

        public void CompleteCaptureTransfer(string transactionId)
        {
            var transactionTransfer = _transactionTransferRepository.GetTransactionTransfer(transactionId);
            transactionTransfer.CompleteCaptureTransfer();
            _transactionTransferRepository.Save(transactionTransfer);
        }

        public void TransferCharge(string transactionId)
        {
            var transactionTransfer = _transactionTransferRepository.GetTransactionTransfer(transactionId);
            transactionTransfer.TransferCharge();
            _transactionTransferRepository.Save(transactionTransfer);
        }

        public void CompleteChargeTransfer(string transactionId)
        {
            var transactionTransfer = _transactionTransferRepository.GetTransactionTransfer(transactionId);
            transactionTransfer.CompleteChargeTransfer();
            _transactionTransferRepository.Save(transactionTransfer);
        }
    }
}