using System;
using Domain.Log.Service;

namespace Domain.Transaction
{
    public class PaymentTransaction
    {
        private readonly ILoggingService _loggingService;

        public PaymentTransaction(
            string transactionId,
            Authorization authorization,
            Capture capture,
            ILoggingService loggingService)
        {
            _loggingService = loggingService;
            TransactionId = transactionId;
            Authorization = authorization;
            Capture = capture;
        }

        public delegate PaymentTransaction Factory(string transactionId, Authorization authorization, Capture capture);

        public string TransactionId { get; private set; }

        public Authorization Authorization { get; private set; }

        public Capture Capture { get; private set; }

        public void AuthorizeTransaction(string account, string currency, int amount)
        {
            Authorization = new Authorization
            {
                TransactionId = TransactionId,
                Account = account,
                Currency = currency,
                Amount = amount,
                CreateUser = Environment.UserName,
                CreateDate = DateTime.Now,
                ModifiedUser = Environment.UserName,
                ModifiedDate = DateTime.Now
            };

            _loggingService.Log(TransactionId, "Transaction authorized");
        }

        public void CaptureTransaction(string currency, int amount)
        {
            Capture = new Capture
            {
                TransactionId = TransactionId,
                Currency = currency,
                Amount = amount,
                CreateUser = Environment.UserName,
                CreateDate = DateTime.Now,
                ModifiedUser = Environment.UserName,
                ModifiedDate = DateTime.Now
            };

            _loggingService.Log(TransactionId, "Transaction captured");
        }
    }
}