namespace Domain.Billing.Repository
{
    public interface IInvoiceRepository
    {
        Invoice GetInvoice(string transactionId);

        void Save(Invoice invoice);
    }
}