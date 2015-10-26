using System;
using Common.DataAccess;
using Domain.Log.Repository;

namespace Domain.Log.Service
{
    public class LoggingService : ILoggingService
    {
        private readonly IPaymentTransactionLogRepository _paymentTransactionLogRepository;

        public LoggingService(IPaymentTransactionLogRepository paymentTransactionLogRepository)
        {
            _paymentTransactionLogRepository = paymentTransactionLogRepository;
        }

        public void Log(string transactionId, string message)
        {
            var log = CreateLog(transactionId, message);
            _paymentTransactionLogRepository.SavePaymentTransactionLog(log);
        }

        private PaymentTransactionLog CreateLog(string transactionId, string message)
        {
            return new PaymentTransactionLog
            {
                TransactionId = transactionId,
                Message = message,
                CreateUser = Environment.UserName,
                CreateDate = DateTime.Now,
                ModifiedUser = Environment.UserName,
                ModifiedDate = DateTime.Now
            };
        }
    }
}