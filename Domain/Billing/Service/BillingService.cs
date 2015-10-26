using Common.DataAccess;
using Domain.Billing.Repository;
using Domain.Transfer.Service;

namespace Domain.Billing.Service
{
    public class BillingService : IBillingService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ITransactionTransferService _transactionTransferService;

        public BillingService(
            IInvoiceRepository invoiceRepository,
            ITransactionTransferService transactionTransferService)
        {
            _invoiceRepository = invoiceRepository;
            _transactionTransferService = transactionTransferService;
        }

        public void ChargeCapture(string transactionId, string currency, int amount)
        {
            var invoice = _invoiceRepository.GetInvoice(transactionId);
            invoice.ChargeCapture(transactionId, currency, amount);

            _invoiceRepository.Save(invoice);

            _transactionTransferService.TransferCharge(transactionId);
        }
    }
}