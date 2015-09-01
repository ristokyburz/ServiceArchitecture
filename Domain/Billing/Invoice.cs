using System;

namespace Domain.Billing
{
    public class Invoice
    {
        public Invoice(Charge charge)
        {
            Charge = charge;
        }

        public delegate Invoice Factory(Charge charge);

        public Charge Charge { get; private set; }

        public void ChargeCapture(string transactionId, string currency, int amount)
        {
            Charge = new Charge
            {
                TransactionId = transactionId,
                ChargeAmount = amount / 150,
                ChargeCurrency = currency,
                CreateUser = Environment.UserName,
                CreateDate = DateTime.Now,
                ModifiedUser = Environment.UserName,
                ModifiedDate = DateTime.Now
            };
        }
    }
}