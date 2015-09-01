using System;
using System.Data;
using Common.DataAccess;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using Environment = NHibernate.Cfg.Environment;

namespace DataAccess
{
    public class NHibernateConfig
    {
        public static ISessionFactory CreateSessionFactory(string moduleName, IsolationLevel isolationLevel, Action<MappingConfiguration> moduleMappings)
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