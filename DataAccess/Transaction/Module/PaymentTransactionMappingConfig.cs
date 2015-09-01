using FluentNHibernate.Cfg;

namespace DataAccess.Transaction.Module
{
    public  class PaymentTransactionMappingConfig : MappingConfig
    {
        public override void Map(MappingConfiguration mapping)
        {
            mapping.FluentMappings
                .Add<AuthorizationMap>()
                .Add<CaptureMap>();
        }
    }
}