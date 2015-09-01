using DataAccess.Transaction.Module;
using Domain.Transaction.Module;

namespace CorePrototype.Module
{
    public class PaymentServiceModule : ServiceModule
    {
        public PaymentServiceModule()
        {
            ModuleName("PaymentModule");

            Module(new PaymentTransactionDataAccessModule());
            Module(new PaymentTransactionServiceModule());

            MappingConfig(new PaymentTransactionMappingConfig());

            IncludeServiceModule(new BillingServiceModule());
            IncludeServiceModule(new TransferServiceModule());
        }
    }
}