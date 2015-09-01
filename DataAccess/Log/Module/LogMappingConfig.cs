using FluentNHibernate.Cfg;

namespace DataAccess.Log.Module
{
    public class LogMappingConfig : MappingConfig
    {
        public override void Map(MappingConfiguration mapping)
        {
            mapping.FluentMappings
                .Add<PaymentTransactionLogMap>();
        }
    }
}