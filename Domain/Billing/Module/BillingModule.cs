using Autofac;
using Common.Container;
using Common.DataAccess;
using Domain.Billing.Repository;
using Domain.Billing.Service;
using Domain.Transfer.Service;

namespace Domain.Billing.Module
{
    public class BillingModule : NamedModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Invoice>();
            builder.Register(x => 
                new BillingService(
                    x.ResolveNamed<IUnitOfWorkFactory>(ModuleName), 
                    x.Resolve<IInvoiceRepository>(),
                    x.Resolve<ITransactionTransferService>()))
                .As<IBillingService>();
        }
    }
}