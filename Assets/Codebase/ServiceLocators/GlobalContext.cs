using Codebase.Library.SAD;
using Codebase.Library.ServiceContainer;

namespace Codebase.ServiceLocators
{
    public class GlobalContext : ServiceLocatorGlobalBootstrapper
    {
        protected override void Bootstrap()
        {
            base.Bootstrap();

            Container.Register(typeof(EntityWorld), new EntityWorld());
        }
    }
}
