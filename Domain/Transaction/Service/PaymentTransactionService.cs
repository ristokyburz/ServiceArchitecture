using System;
using Common.DataAccess;
using Domain.Billing.Service;
using Domain.Transaction.Repository;
using Domain.Transfer.Service;

namespace Domain.Transaction.Service
{
    public class PaymentTransactionService : IPaymentTransactionService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPaymentTransactionRepository _paymentTransactionRepository;
        private readonly IBillingService _billingService;
        private readonly ITransactionTransferService _transactionTransferService;

        public PaymentTransactionService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IPaymentTransactionRepository paymentTransactionRepository,
            IBillingService billingService,
            ITransactionTransferService transactionTransferService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _paymentTransactionRepository = paymentTransactionRepository;
            _billingService = billingService;
            _transactionTransferService = transactionTransferService;
        }

        public void AuthorizeTransaction(string account, string currency, int amount)
        {
            using (var unitOfWork = _unitOfWorkFactory.UnitOfWork())
            {
                var paymentTransaction = _paymentTransactionRepository.GetPaymentTransaction(Guid.NewGuid().ToString());

                paymentTransaction.AuthorizeTransaction(account, currency, amount);

                _paymentTransactionRepository.Save(paymentTransaction);

                unitOfWork.Commit();
            }
        }

        public void CaptureTransaction(string transactionId, string currency, int amount)
        {
            using (var unitOfWork = _unitOfWorkFactory.UnitOfWork())
            {
                var paymentTransaction = _paymentTransactionRepository.GetPaymentTransaction(transactionId);

                paymentTransaction.CaptureTransaction(currency, amount);

                _paymentTransactionRepository.Save(paymentTransaction);

                unitOfWork.Commit();
            }
        }

        public void AuthorizeAutoCaptureTransaction(string account, string currency, int amount)
        {
            using (var unitOfWork = _unitOfWorkFactory.UnitOfWork())
            {
                var paymentTransaction = _paymentTransactionRepository.GetPaymentTransaction(Guid.NewGuid().ToString());

                paymentTransaction.AuthorizeTransaction(account, currency, amount);
                paymentTransaction.CaptureTransaction(currency, amount);

                _paymentTransactionRepository.Save(paymentTransaction);

                unitOfWork.Commit();
            }
        }

        public void AuthorizeAutoCaptureTransactionWithInvoice(string account, string currency, int amount)
        {
            using (var unitOfWork = _unitOfWorkFactory.UnitOfWork())
            {
                var paymentTransaction = _paymentTransactionRepository.GetPaymentTransaction(Guid.NewGuid().ToString());

                paymentTransaction.AuthorizeTransaction(account, currency, amount);
                paymentTransaction.CaptureTransaction(currency, amount);

                _paymentTransactionRepository.Save(paymentTransaction);

                _billingService.ChargeCapture(paymentTransaction.TransactionId, currency, amount);

                unitOfWork.Commit();
            }
        }

        public void AuthorizeAutoCaptureTransactionWithInvoiceAndTransfer(string account, string currency, int amount)
        {
            using (var unitOfWork = _unitOfWorkFactory.UnitOfWork())
            {
                var paymentTransaction = _paymentTransactionRepository.GetPaymentTransaction(Guid.NewGuid().ToString());

                paymentTransaction.AuthorizeTransaction(account, currency, amount);
                paymentTransaction.CaptureTransaction(currency, amount);

                _paymentTransactionRepository.Save(paymentTransaction);

                _billingService.ChargeCapture(paymentTransaction.TransactionId, currency, amount);

                _transactionTransferService.TransferCapture(paymentTransaction.TransactionId);

                unitOfWork.Commit();
            }
        }
    }
}