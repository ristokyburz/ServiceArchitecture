using Autofac;

namespace Common.Container
{
    public class NamedModule : Module
    {
        protected string ModuleName { get; private set; }

        public void SetName(string moduleName)
        {
            ModuleName = moduleName;
        }
    }
}