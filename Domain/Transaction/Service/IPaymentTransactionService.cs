namespace Domain.Transaction.Service
{
    public interface IPaymentTransactionService
    {
        void AuthorizeTransaction(string account, string currency, int amount);

        void CaptureTransaction(string transactionId, string currency, int amount);

        void AuthorizeAutoCaptureTransaction(string account, string currency, int amount);

        void AuthorizeAutoCaptureTransactionWithInvoice(string account, string currency, int amount);

        void AuthorizeAutoCaptureTransactionWithInvoiceAndTransfer(string account, string currency, int amount);
    }
}