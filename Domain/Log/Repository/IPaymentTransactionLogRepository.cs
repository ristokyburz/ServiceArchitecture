using System.Collections.Generic;

namespace Domain.Log.Repository
{
    public interface IPaymentTransactionLogRepository
    {
        ICollection<PaymentTransactionLog> GetPaymentTransactionLogs(string transactionId);

        void SavePaymentTransactionLog(PaymentTransactionLog paymentTransactionLog);
    }
}