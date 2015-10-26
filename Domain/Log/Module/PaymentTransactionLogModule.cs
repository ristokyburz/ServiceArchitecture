using Autofac;
using Common.Container;
using Common.DataAccess;
using Domain.Log.Repository;
using Domain.Log.Service;

namespace Domain.Log.Module
{
    public class PaymentTransactionLogModule : NamedModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => new LoggingService(x.Resolve<IPaymentTransactionLogRepository>())).As<ILoggingService>();
        }
    }
}