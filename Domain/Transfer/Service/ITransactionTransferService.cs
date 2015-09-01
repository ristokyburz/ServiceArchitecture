namespace Domain.Transfer.Service
{
    public interface ITransactionTransferService
    {
        void TransferCapture(string transactionId);

        void CompleteCaptureTransfer(string transactionId);

        void TransferCharge(string transactionId);

        void CompleteChargeTransfer(string transactionId);
    }
}