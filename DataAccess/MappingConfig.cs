using FluentNHibernate.Cfg;

namespace DataAccess
{
    public abstract class MappingConfig
    {
        public abstract void Map(MappingConfiguration mapping);
    }
}