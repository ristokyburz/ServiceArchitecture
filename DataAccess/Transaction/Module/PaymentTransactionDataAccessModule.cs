using Autofac;
using Common.Container;
using Common.DataAccess;
using DataAccess.Transaction.Repository;
using Domain.Transaction;
using Domain.Transaction.Repository;

namespace DataAccess.Transaction.Module
{
    public class PaymentTransactionDataAccessModule : NamedModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => new PaymentTransactionRepository(x.ResolveNamed<IUnitOfWorkFactory>(ModuleName), x.Resolve<PaymentTransaction.Factory>())).As<IPaymentTransactionRepository>();
            builder.Register(x => new AuthorizationRepository(x.ResolveNamed<IUnitOfWorkFactory>(ModuleName))).As<IAuthorizationRepository>();
            builder.Register(x => new CaptureRepository(x.ResolveNamed<IUnitOfWorkFactory>(ModuleName))).As<ICaptureRepository>();
        }
    }
}