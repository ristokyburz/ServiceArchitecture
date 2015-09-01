using Autofac;
using Common.Container;
using Common.DataAccess;
using DataAccess.Log.Repository;
using Domain.Log.Repository;

namespace DataAccess.Log.Module
{
    public class LogDataAccessModule : NamedModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => new PaymentTransactionLogRepository(x.ResolveNamed<IUnitOfWorkFactory>(ModuleName))).As<IPaymentTransactionLogRepository>();
        }
    }
}