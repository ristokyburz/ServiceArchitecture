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
        public PaymentTransactionLogRepository(IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
        }

        public ICollection<PaymentTransactionLog> GetPaymentTransactionLogs(string transactionId)
        {
            using (var unitOfWork = UnitOfWorkFactory.UnitOfWork())
            {
                var logs = unitOfWork
                    .Session
                    .Query<PaymentTransactionLog>()
                    .Where(x => x.TransactionId == transactionId)
                    .ToList();

                unitOfWork.Commit();

                return logs;
            }
        }

        public void SavePaymentTransactionLog(PaymentTransactionLog paymentTransactionLog)
        {
            using (var unitOfWork = UnitOfWorkFactory.UnitOfWork())
            {
                unitOfWork.Session.SaveOrUpdate(paymentTransactionLog);
                unitOfWork.Commit();
            }
        }
    }
}