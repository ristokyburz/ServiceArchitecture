namespace Domain.Transaction.Repository
{
    public interface ICaptureRepository
    {
        Capture GetCapture(string transactionId);
    }
}