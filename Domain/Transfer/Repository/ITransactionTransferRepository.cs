namespace Domain.Transfer.Repository
{
    public interface ITransactionTransferRepository
    {
        TransactionTransfer GetTransactionTransfer(string transactionId);

        void Save(TransactionTransfer transactionTransfer);
    }
}