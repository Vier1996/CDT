using InternalAssets.Codebase.Gameplay.Behaviors;
using InternalAssets.Codebase.Gameplay.Workplaces;
using InternalAssets.Codebase.Library.ServiceContainer;

namespace InternalAssets.Codebase.ServiceLocators
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
