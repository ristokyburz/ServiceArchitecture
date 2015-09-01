using DataAccess.Transfer.Module;
using Domain.Transfer.Module;

namespace CorePrototype.Module
{
    public class TransferServiceModule : ServiceModule
    {
        public TransferServiceModule()
        {
            ModuleName("TransferModule");

            Module(new TransferDataAccessModule());
            Module(new TransferDomainServiceModule());

            MappingConfig(new TransferMappingConfig());
        }   
    }
}