using System.Collections.Generic;
using System.Data;
using Common.Container;
using DataAccess;

namespace CorePrototype.Module
{
    public abstract class ServiceModule
    {
        protected ServiceModule()
        {
            IsolationLevel = IsolationLevel.ReadCommitted;
            Modules = new List<NamedModule>();
            Mappings = new List<MappingConfig>();
        }

        public string Name { get; private set; }

        public List<NamedModule> Modules { get; private set; }

        public List<MappingConfig> Mappings { get; private set; }

        public IsolationLevel IsolationLevel { get; private set; }

        protected void IncludeServiceModule(ServiceModule serviceModule)
        {
            Modules.AddRange(serviceModule.Modules);
            Mappings.AddRange(serviceModule.Mappings);   
        }

        protected void ModuleName(string name)
        {
            Name = name;
        }

        protected void SetIsolationLevel(IsolationLevel isolationLevel)
        {
            IsolationLevel = isolationLevel;
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