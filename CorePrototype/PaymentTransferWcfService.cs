using System.Collections.Generic;
using Autofac;
using CorePrototype.Module;
using Domain.Transfer.Service;

namespace CorePrototype
{
    public class PaymentTransferWcfService
    {
        private readonly ITransactionTransferService _transactionTransferService;

        public PaymentTransferWcfService()
        {
            var moduleBuilder = new ServiceModuleBuilder(
                new List<ServiceModule>
                {
                    new TransferServiceModule(),
                    new LoggingServiceModule()
                
                });

            moduleBuilder.Build();
            _transactionTransferService = moduleBuilder.Container.Resolve<ITransactionTransferService>();
        }

        public void TransferAndTransaction(string transactionId)
        {
            _transactionTransferService.TransferCapture(transactionId);
            _transactionTransferService.TransferCharge(transactionId);

            _transactionTransferService.CompleteCaptureTransfer(transactionId);
            _transactionTransferService.CompleteChargeTransfer(transactionId);
        }
    }
}