using System.Data;
using DataAccess.Transfer.Module;
using Domain.Transfer.Module;

namespace CorePrototype.Module
{
    public class TransferServiceModule : ServiceModule
    {
        public TransferServiceModule()
        {
			SetIsolationLevel(IsolationLevel.ReadUncommitted);

            ModuleName("TransferModule");

            Module(new TransferDataAccessModule());
            Module(new TransferDomainServiceModule());

            MappingConfig(new TransferMappingConfig());
        }   
    }
}