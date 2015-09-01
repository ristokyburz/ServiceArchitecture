using Autofac;
using Common.Container;
using Common.DataAccess;
using Domain.Billing.Service;
using Domain.Transaction.Repository;
using Domain.Transaction.Service;
using Domain.Transfer.Service;

namespace Domain.Transaction.Module
{
    public class PaymentTransactionServiceModule : NamedModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PaymentTransaction>();
            builder.Register(x =>
                new PaymentTransactionService(
                    x.ResolveNamed<IUnitOfWorkFactory>(ModuleName), 
                    x.Resolve<IPaymentTransactionRepository>(),
                    x.Resolve<IBillingService>(), 
                    x.Resolve<ITransactionTransferService>()))
                .As<IPaymentTransactionService>();
        }
    }
}