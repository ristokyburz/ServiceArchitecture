namespace Domain.Billing
{
    public class Charge : Entity
    {
        public virtual string TransactionId { get; set; }

        public virtual string ChargeCurrency { get; set; }

        public virtual int ChargeAmount { get; set; }
    }
}