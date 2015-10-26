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

        public InvoiceRepository(ISimpleUnitOfWork unitOfWork, Invoice.Factory invoiceFactory) : base(unitOfWork)
        {
            _invoiceFactory = invoiceFactory;
        }

        public Invoice GetInvoice(string transactionId)
        {
            var charge = UnitOfWork
                .Session
                .Query<Charge>()
                .SingleOrDefault(x => x.TransactionId == transactionId);

            return _invoiceFactory(charge);
        }

        public void Save(Invoice invoice)
        {
            UnitOfWork.Session.SaveOrUpdate(invoice.Charge);
        }
    }
}