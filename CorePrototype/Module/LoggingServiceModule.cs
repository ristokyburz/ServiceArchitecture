using DataAccess.Log.Module;
using Domain.Log.Module;

namespace CorePrototype.Module
{
    public class LoggingServiceModule : ServiceModule
    {
        public LoggingServiceModule()
        {
            ModuleName("LoggingModule");

            Module(new LogDataAccessModule());
            Module(new PaymentTransactionLogModule());

            MappingConfig(new LogMappingConfig());
        }
    }
}