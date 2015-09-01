using DataAccess.Billing.Module;
using Domain.Billing.Module;

namespace CorePrototype.Module
{
    public class BillingServiceModule : ServiceModule
    {
        public BillingServiceModule()
        {
            ModuleName("BillingModule");

            Module(new BillingDataAccessModule());
            Module(new BillingModule());

            MappingConfig(new BillingMappingConfig());

            IncludeServiceModule(new TransferServiceModule());
        }
    }
}