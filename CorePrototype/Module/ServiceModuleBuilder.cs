using System.Collections.Generic;
using System.Data;
using System.Linq;
using Autofac;
using DataAccess;

namespace CorePrototype.Module
{
    public class ServiceModuleBuilder
    {
        private readonly ICollection<ServiceModule> _serviceModules;
        private readonly ContainerBuilder _builder;
        private readonly SessionFactoryBuilder _sessionFactoryBuilder;

        public ServiceModuleBuilder(ICollection<ServiceModule> serviceModules)
        {
            _serviceModules = serviceModules;
            _builder = new ContainerBuilder();
            _sessionFactoryBuilder = new SessionFactoryBuilder();
        }

        public IContainer Container { get; private set; }

        public void Build()
        {
            RegisterAutofacModules();
            RegisterNHibernateConfigs();
            Container = _builder.Build();
        }

        private void RegisterAutofacModules()
        {
            foreach (var serviceModule in _serviceModules)
            {
                var modulesDistincted = GetItemsDistincted(serviceModule.Modules);
                foreach (var module in modulesDistincted)
                {
                    module.SetName(serviceModule.Name);
                    _builder.RegisterModule(module);
                }   
            }
        }

        private void RegisterNHibernateConfigs()
        {
            foreach (var serviceModule in _serviceModules)
            {
                var mappingsDistincted = GetItemsDistincted(serviceModule.Mappings);
                _sessionFactoryBuilder.Build(_builder, mappingsDistincted, serviceModule.Name, serviceModule.IsolationLevel);   
            }
        }

        private static List<T> GetItemsDistincted<T>(List<T> listWithTypeDublicates)
        {
            var mappings = new List<T>();
            foreach (var item in listWithTypeDublicates)
            {
                if (!mappings.Select(x => x.GetType()).Contains(item.GetType()))
                {
                    mappings.Add(item);
                }
            }

            return mappings;
        }
    }
}