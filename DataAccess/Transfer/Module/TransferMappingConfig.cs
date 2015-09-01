using FluentNHibernate.Cfg;

namespace DataAccess.Transfer.Module
{
    public class TransferMappingConfig : MappingConfig
    {
        public override void Map(MappingConfiguration mapping)
        {
            mapping.FluentMappings
                .Add<CaptureTransferMap>()
                .Add<ChargeTransferMap>();
        }
    }
}