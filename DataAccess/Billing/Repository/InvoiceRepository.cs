using System.Linq;
using Common.DataAccess;
using Domain.Billing;
using Domain.Billing.Repository;
using NHibernate.Linq;

namespace DataAccess.Billing.Repository
{
    public class InvoiceRepository : RepositoryBase, IInvoiceRepository
    {
        private readonly Invoice.Factory _invoiceFactory;

        public InvoiceRepository(IUnitOfWorkFactory unitOfWorkFactory, Invoice.Factory invoiceFactory) : base(unitOfWorkFactory)
        {
            _invoiceFactory = invoiceFactory;
        }

        public Invoice GetInvoice(string transactionId)
        {
            using (var unitOfWork = UnitOfWorkFactory.UnitOfWork())
            {
                var charge = unitOfWork
                    .Session
                    .Query<Charge>()
                    .SingleOrDefault(x => x.TransactionId == transactionId);

                unitOfWork.Commit();

                return _invoiceFactory(charge);
            }
        }

        public void Save(Invoice invoice)
        {
            using (var unitOfWork = UnitOfWorkFactory.UnitOfWork())
            {
                unitOfWork.Session.SaveOrUpdate(invoice.Charge);
                unitOfWork.Commit();
            }
        }
    }
}