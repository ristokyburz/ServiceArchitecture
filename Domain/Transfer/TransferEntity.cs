using System;

namespace Domain.Transfer
{
    public class TransferEntity : Entity
    {
        public virtual DateTime TransferDate { get; set; }

        public virtual TransferStateType TransferState { get; set; }
    }

    public enum TransferStateType
    {
        ReadyForProcess,
        Processed,
        Failed
    }
}