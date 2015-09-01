namespace Domain.Transaction.Repository
{
    public interface IPaymentTransactionRepository
    {
        PaymentTransaction GetPaymentTransaction(string transactionId);

        void Save(PaymentTransaction paymentTransaction);
    }
}