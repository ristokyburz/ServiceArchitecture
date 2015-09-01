namespace Domain.Log
{
    public class PaymentTransactionLog : Entity
    {
        public virtual string TransactionId { get; set; }

        public virtual string Message { get; set; }
    }
}