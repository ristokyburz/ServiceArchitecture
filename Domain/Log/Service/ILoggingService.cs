namespace Domain.Log.Service
{
    public interface ILoggingService
    {
        void Log(string transactionId, string message);
    }
}