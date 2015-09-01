using Autofac;
using Common.Container;
using Common.DataAccess;
using Domain.Transfer.Repository;
using Domain.Transfer.Service;

namespace Domain.Transfer.Module
{
    public class TransferDomainServiceModule : NamedModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TransactionTransfer>();
            builder.Register(x => new TransactionTransferService(x.ResolveNamed<IUnitOfWorkFactory>(ModuleName), x.Resolve<ITransactionTransferRepository>())).As<ITransactionTransferService>();
        }
    }
}