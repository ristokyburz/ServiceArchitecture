using System.Collections.Generic;
using System.Linq;
using Common.DataAccess;
using Domain.Log;
using Domain.Log.Repository;
using NHibernate.Linq;

namespace DataAccess.Log.Repository
{
    public class PaymentTransactionLogRepository : RepositoryBase, IPaymentTransactionLogRepository
    {
        public PaymentTransactionLogRepository(ISimpleUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public ICollection<PaymentTransactionLog> GetPaymentTransactionLogs(string transactionId)
        {
            var logs = UnitOfWork
                .Session
                .Query<PaymentTransactionLog>()
                .Where(x => x.TransactionId == transactionId)
                .ToList();

            return logs;
        }

        public void SavePaymentTransactionLog(PaymentTransactionLog paymentTransactionLog)
        {
            UnitOfWork.Session.SaveOrUpdate(paymentTransactionLog);
        }
    }
}