using Codebase.Gameplay.Behaviors;
using Codebase.Gameplay.Workplaces;
using Codebase.Library.ServiceContainer;

namespace Codebase.ServiceLocators
{
    public class LocalContext : ServiceLocatorSceneBootstrapper
    {
        protected override void Bootstrap()
        {
            base.Bootstrap();

            Container.Register(typeof(WorkplaceService), new WorkplaceService());
            Container.Register(typeof(BehaviorService), new BehaviorService());
        }
    }
}
