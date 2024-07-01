using InternalAssets.Codebase.Library.SAD;
using InternalAssets.Codebase.Library.ServiceContainer;

namespace InternalAssets.Codebase.ServiceLocators
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
