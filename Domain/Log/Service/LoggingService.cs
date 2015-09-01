using System;
using Common.DataAccess;
using Domain.Log.Repository;

namespace Domain.Log.Service
{
    public class LoggingService : ILoggingService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPaymentTransactionLogRepository _paymentTransactionLogRepository;

        public LoggingService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IPaymentTransactionLogRepository paymentTransactionLogRepository)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _paymentTransactionLogRepository = paymentTransactionLogRepository;
        }

        public void Log(string transactionId, string message)
        {
            using (var unitOfWork = _unitOfWorkFactory.UnitOfWork())
            {
                var log = CreateLog(transactionId, message);
                _paymentTransactionLogRepository.SavePaymentTransactionLog(log);

                unitOfWork.Commit();
            }
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