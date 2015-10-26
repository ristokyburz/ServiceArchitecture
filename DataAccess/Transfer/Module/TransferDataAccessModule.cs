using Autofac;
using Common.Container;
using Common.DataAccess;
using DataAccess.Transfer.Repository;
using Domain.Transfer;
using Domain.Transfer.Repository;

namespace DataAccess.Transfer.Module
{
    public class TransferDataAccessModule : NamedModule
    {
        protected override void Load(ContainerBuilder builder)
        {
			builder.Register(x => new TransactionTransferRepository(x.ResolveNamed<ISimpleUnitOfWork>(ModuleName), x.Resolve<TransactionTransfer.Factory>())).As<ITransactionTransferRepository>();
        } 
    }
}