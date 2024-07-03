using ACS.Core.ServicesContainer;
using InternalAssets.Codebase.Gameplay.Behaviors;
using InternalAssets.Codebase.Gameplay.Workplaces;

namespace InternalAssets.Codebase.ServiceLocators
{
    public class LocalContext : ServiceContainerLocal
    {
        protected override void Bootstrap()
        {
            base.Bootstrap();

            Container.Register(typeof(WorkplaceService), new WorkplaceService());
            Container.Register(typeof(BehaviorService), new BehaviorService());
        }
    }
}
