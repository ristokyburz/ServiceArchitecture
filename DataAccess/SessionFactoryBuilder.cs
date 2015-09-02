using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Autofac;
using Common.DataAccess;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using Environment = NHibernate.Cfg.Environment;

namespace DataAccess
{
    public class SessionFactoryBuilder
    {
        private ICollection<MappingConfig> _maps;

        public void Build(ContainerBuilder builder, ICollection<MappingConfig> maps, string moduleName, IsolationLevel isolationLevel)
        {
            _maps = maps;
            var factory = CreateSessionFactory(moduleName, isolationLevel, Map);

            builder.Register(x => new UnitOfWorkFactory(factory))
                .InstancePerLifetimeScope()
                .Named<IUnitOfWorkFactory>(moduleName);
        }

        private void Map(MappingConfiguration mapping)
        {
            foreach (var mappingConfig in _maps)
            {
                mappingConfig.Map(mapping);
            }
        }

        private ISessionFactory CreateSessionFactory(string moduleName, IsolationLevel isolationLevel, Action<MappingConfiguration> moduleMappings)
        {
            string connectionString = @"yourConnectionString";
            connectionString += ";Application Name=" + moduleName;

            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString)
                    .ShowSql()
                    .FormatSql()
                    .UseOuterJoin()
                    .UseReflectionOptimizer()
                    .IsolationLevel(isolationLevel))
                .ExposeConfiguration(Configuration)
                .Mappings(moduleMappings)
                .ExposeConfiguration(x => x.SetInterceptor(new GeneralNHibernateInterceptor())) // Only 1 interceptor is allowed per session
                .BuildSessionFactory();
        }

        private static void Configuration(Configuration config)
        {
            config
                .SetProperty(Environment.SqlExceptionConverter, typeof(MsSqlExceptionConverter).AssemblyQualifiedName)
                .SetProperty(Environment.UseSqlComments, "true");
        }
    }
}