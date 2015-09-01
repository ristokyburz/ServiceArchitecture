namespace Domain.Transaction
{
    public class Authorization : Entity
    {
        public virtual string TransactionId { get; set; }

        public virtual string Account { get; set; }

        public virtual string Currency { get; set; }

        public virtual int Amount { get; set; }
    }
}