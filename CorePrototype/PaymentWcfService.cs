using System.Collections.Generic;
using Autofac;
using CorePrototype.Module;
using Domain.Transaction.Service;

namespace CorePrototype
{
    public class PaymentWcfService
    {
        private readonly IPaymentTransactionService _paymentTransactionService;

        public PaymentWcfService()
        {
            var moduleBuilder = new ServiceModuleBuilder
                (new List<ServiceModule>
                {
                    new PaymentServiceModule(), 
                    new LoggingServiceModule()
                });

            moduleBuilder.Build();
            _paymentTransactionService = moduleBuilder.Container.Resolve<IPaymentTransactionService>();
        }

        public void AuthorizePaymentTransaction(string account, string currency, int amount)
        {
            _paymentTransactionService.AuthorizeTransaction(account, currency, amount);
        }

        public void CapturePaymentTransaction(string transactionId, string currency, int amount)
        {
            _paymentTransactionService.CaptureTransaction(transactionId, currency, amount);
        }

        public void AuthorizeAutoCaptureTransaction(string account, string currency, int amount)
        {
            _paymentTransactionService.AuthorizeAutoCaptureTransaction(account, currency, amount);
        }

        public void AuthorizeAutoCaptureWithInvoice(string account, string currency, int amount)
        {
            _paymentTransactionService.AuthorizeAutoCaptureTransactionWithInvoice(account, currency, amount);
        }

        public void AuthorizeAutoCaptureTransactionWithInvoiceAndTransfer(string account, string currency, int amount)
        {
            _paymentTransactionService.AuthorizeAutoCaptureTransactionWithInvoiceAndTransfer(account, currency, amount);   
        }
    }
}