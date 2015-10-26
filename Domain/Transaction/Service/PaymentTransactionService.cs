using System;
using Common.DataAccess;
using Domain.Billing.Service;
using Domain.Transaction.Repository;
using Domain.Transfer.Service;

namespace Domain.Transaction.Service
{
    public class PaymentTransactionService : IPaymentTransactionService
    {
        private readonly IPaymentTransactionRepository _paymentTransactionRepository;
        private readonly IBillingService _billingService;
        private readonly ITransactionTransferService _transactionTransferService;

        public PaymentTransactionService(
            IPaymentTransactionRepository paymentTransactionRepository,
            IBillingService billingService,
            ITransactionTransferService transactionTransferService)
        {
            _paymentTransactionRepository = paymentTransactionRepository;
            _billingService = billingService;
            _transactionTransferService = transactionTransferService;
        }

        public void AuthorizeTransaction(string account, string currency, int amount)
        {
            var paymentTransaction = _paymentTransactionRepository.GetPaymentTransaction(Guid.NewGuid().ToString());
            paymentTransaction.AuthorizeTransaction(account, currency, amount);
            _paymentTransactionRepository.Save(paymentTransaction);
        }

        public void CaptureTransaction(string transactionId, string currency, int amount)
        {
                var paymentTransaction = _paymentTransactionRepository.GetPaymentTransaction(transactionId);
                paymentTransaction.CaptureTransaction(currency, amount);
                _paymentTransactionRepository.Save(paymentTransaction);
        }

        public void AuthorizeAutoCaptureTransaction(string account, string currency, int amount)
        {
            var paymentTransaction = _paymentTransactionRepository.GetPaymentTransaction(Guid.NewGuid().ToString());

            paymentTransaction.AuthorizeTransaction(account, currency, amount);
            paymentTransaction.CaptureTransaction(currency, amount);

            _paymentTransactionRepository.Save(paymentTransaction);
        }

        public void AuthorizeAutoCaptureTransactionWithInvoice(string account, string currency, int amount)
        {
            var paymentTransaction = _paymentTransactionRepository.GetPaymentTransaction(Guid.NewGuid().ToString());

            paymentTransaction.AuthorizeTransaction(account, currency, amount);
            paymentTransaction.CaptureTransaction(currency, amount);

            _paymentTransactionRepository.Save(paymentTransaction);

            _billingService.ChargeCapture(paymentTransaction.TransactionId, currency, amount);
        }

        public void AuthorizeAutoCaptureTransactionWithInvoiceAndTransfer(string account, string currency, int amount)
        {
            var paymentTransaction = _paymentTransactionRepository.GetPaymentTransaction(Guid.NewGuid().ToString());

            paymentTransaction.AuthorizeTransaction(account, currency, amount);
            paymentTransaction.CaptureTransaction(currency, amount);

            _paymentTransactionRepository.Save(paymentTransaction);

            _billingService.ChargeCapture(paymentTransaction.TransactionId, currency, amount);

            _transactionTransferService.TransferCapture(paymentTransaction.TransactionId);
        }
    }
}