using System.Collections.Generic;
using Common.Container;
using DataAccess;

namespace CorePrototype.Module
{
    public abstract class ServiceModule
    {
        protected ServiceModule()
        {
            Modules = new List<NamedModule>();
            Mappings = new List<MappingConfig>();
        }

        public string Name { get; private set; }

        public List<NamedModule> Modules { get; private set; }

        public List<MappingConfig> Mappings { get; private set; }

        protected void IncludeServiceModule(ServiceModule serviceModule)
        {
            Modules.AddRange(serviceModule.Modules);
            Mappings.AddRange(serviceModule.Mappings);   
        }

        protected void ModuleName(string name)
        {
            Name = name;
        }

        protected void Module(NamedModule module)
        {
            Modules.Add(module);
        }

        protected void MappingConfig(MappingConfig mappingConfig)
        {
            Mappings.Add(mappingConfig);
        }
    }
}