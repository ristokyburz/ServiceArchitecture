using Common.DataAccess;
using Domain.Billing.Repository;
using Domain.Transfer.Service;

namespace Domain.Billing.Service
{
    public class BillingService : IBillingService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ITransactionTransferService _transactionTransferService;

        public BillingService(
            IUnitOfWorkFactory unitOfWorkFactory, 
            IInvoiceRepository invoiceRepository,
            ITransactionTransferService transactionTransferService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _invoiceRepository = invoiceRepository;
            _transactionTransferService = transactionTransferService;
        }

        public void ChargeCapture(string transactionId, string currency, int amount)
        {
            using (var unitOfWork = _unitOfWorkFactory.UnitOfWork())
            {
                var invoice = _invoiceRepository.GetInvoice(transactionId);
                invoice.ChargeCapture(transactionId, currency, amount);

                _invoiceRepository.Save(invoice);

                _transactionTransferService.TransferCharge(transactionId);

                unitOfWork.Commit();
            }
        }
    }
}