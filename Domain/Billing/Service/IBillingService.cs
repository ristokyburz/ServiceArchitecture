namespace Domain.Billing.Service
{
    public interface IBillingService
    {
        void ChargeCapture(string transactionId, string currency, int amount);
    }
}