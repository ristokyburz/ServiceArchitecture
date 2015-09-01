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
            IUnitOfWorkFactory unitOfWorkFactory,
            PaymentTransaction.Factory paymentTransactionFactory)
            : base(unitOfWorkFactory)
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
            using (var unitOfWork = UnitOfWorkFactory.UnitOfWork())
            {
                var capture = unitOfWork
                    .Session
                    .Query<Capture>()
                    .SingleOrDefault(x => x.TransactionId == transactionId);

                unitOfWork.Commit();

                return capture;
            }
        }

        public Authorization GetAuthorization(string transactionId)
        {
            using (var unitOfWork = UnitOfWorkFactory.UnitOfWork())
            {
                var authorization = unitOfWork
                    .Session
                    .Query<Authorization>()
                    .SingleOrDefault(x => x.TransactionId == transactionId);

                unitOfWork.Commit();

                return authorization;
            }
        }
    }
}