namespace Domain.Transaction.Repository
{
    public interface IAuthorizationRepository
    {
        Authorization GetAuthorization(string transactionId);
    }
}