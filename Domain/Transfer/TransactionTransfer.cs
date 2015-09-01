using System;
using Domain.Log.Service;

namespace Domain.Transfer
{
    public class TransactionTransfer
    {
        private readonly string _transactionId;
        private readonly ILoggingService _loggingService;

        public TransactionTransfer(
            string transactionId,
            CaptureTransfer captureTransfer,
            ChargeTransfer chargeTransfer,
            ILoggingService loggingService
            )
        {
            _transactionId = transactionId;
            CaptureTransfer = captureTransfer;
            ChargeTransfer = chargeTransfer;
            _loggingService = loggingService;
        }

        public CaptureTransfer CaptureTransfer { get; private set; }

        public ChargeTransfer ChargeTransfer { get; private set; }

        public delegate TransactionTransfer Factory(string transactionId, CaptureTransfer captureTransfer, ChargeTransfer chargeTransfer);

        public void TransferCapture()
        {
            if (CaptureTransfer == null)
            {
                CaptureTransfer = new CaptureTransfer
                {
                    TransactionId = _transactionId,
                    TransferDate = DateTime.Now,
                    TransferState = TransferStateType.ReadyForProcess,
                    CreateUser = Environment.UserName,
                    CreateDate = DateTime.Now,
                    ModifiedUser = Environment.UserName,
                    ModifiedDate = DateTime.Now
                };

                _loggingService.Log(_transactionId, "Transfer capture.");   
            }
        }

        public void CompleteCaptureTransfer()
        {
            CaptureTransfer.TransferState = TransferStateType.Processed;
            CaptureTransfer.ModifiedUser = Environment.UserName;
            CaptureTransfer.ModifiedDate = DateTime.Now;

            _loggingService.Log(_transactionId, "Transfer capture completed.");
        }

        public void TransferCharge()
        {
            if (ChargeTransfer == null)
            {
                ChargeTransfer = new ChargeTransfer
                {
                    TransactionId = _transactionId,
                    TransferDate = DateTime.Now,
                    TransferState = TransferStateType.ReadyForProcess,
                    CreateUser = Environment.UserName,
                    CreateDate = DateTime.Now,
                    ModifiedUser = Environment.UserName,
                    ModifiedDate = DateTime.Now
                };

                _loggingService.Log(_transactionId, "Transfer charge.");        
            }       
        }

        public void CompleteChargeTransfer()
        {
            ChargeTransfer.TransferState = TransferStateType.Processed;
            ChargeTransfer.ModifiedUser = Environment.UserName;
            ChargeTransfer.ModifiedDate = DateTime.Now;

            _loggingService.Log(_transactionId, "Charge capture completed.");            
        }
    }
}