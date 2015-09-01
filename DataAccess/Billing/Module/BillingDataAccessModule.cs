using Autofac;
using Common.Container;
using Common.DataAccess;
using DataAccess.Billing.Repository;
using Domain.Billing;
using Domain.Billing.Repository;

namespace DataAccess.Billing.Module
{
    public class BillingDataAccessModule : NamedModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => new InvoiceRepository(x.ResolveNamed<IUnitOfWorkFactory>(ModuleName), x.Resolve<Invoice.Factory>())).As<IInvoiceRepository>();
        }
    }
}