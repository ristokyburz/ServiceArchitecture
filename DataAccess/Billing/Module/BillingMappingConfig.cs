using FluentNHibernate.Cfg;

namespace DataAccess.Billing.Module
{
    public class BillingMappingConfig : MappingConfig
    {
        public override void Map(MappingConfiguration mapping)
        {
            mapping.FluentMappings
                .Add<ChargeMap>();
        }
    }
}