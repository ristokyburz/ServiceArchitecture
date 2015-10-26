using System.Linq;
using Common.DataAccess;
using Domain.Transaction;
using Domain.Transaction.Repository;
using NHibernate.Linq;

namespace DataAccess.Transaction.Repository
{
    public class PaymentTransactionRepository : RepositoryBase, IPaymentTransactionRepository
    {
        private readonly PaymentTransaction.Factory _paymentTransactionFactory;

        public PaymentTransactionRepository(
            ISimpleUnitOfWork unitOfWork,
            PaymentTransaction.Factory paymentTransactionFactory)
            : base(unitOfWork)
        {
            _paymentTransactionFactory = paymentTransactionFactory;
        }

        public PaymentTransaction GetPaymentTransaction(string transactionId)
        {
            var authorization = GetAuthorization(transactionId);
            var capture = GetCapture(transactionId);

            return _paymentTransactionFactory(transactionId, authorization, capture);
        }

        public void Save(PaymentTransaction paymentTransaction)
        {
            Save(paymentTransaction.Authorization);
            Save(paymentTransaction.Capture);
        }

        private Capture GetCapture(string transactionId)
        {
            var capture = UnitOfWork
                .Session
                .Query<Capture>()
                .SingleOrDefault(x => x.TransactionId == transactionId);

            return capture;
        }

        public Authorization GetAuthorization(string transactionId)
        {
            var authorization = UnitOfWork
                .Session
                .Query<Authorization>()
                .SingleOrDefault(x => x.TransactionId == transactionId);

            return authorization;
        }
    }
}