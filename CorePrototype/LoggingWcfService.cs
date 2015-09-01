using System.Collections.ObjectModel;
using Autofac;
using CorePrototype.Module;
using Domain.Log.Service;

namespace CorePrototype
{
    public class LoggingWcfService
    {
        private readonly ILoggingService _loggingService;

        public LoggingWcfService()
        {
            var loggingBuilder = new ServiceModuleBuilder(new Collection<ServiceModule> { new LoggingServiceModule() });
            loggingBuilder.Build();

            _loggingService = loggingBuilder.Container.Resolve<ILoggingService>();
        }

        public void Log(string transactionId, string message)
        {
            _loggingService.Log(transactionId, message);
        }
    }
}