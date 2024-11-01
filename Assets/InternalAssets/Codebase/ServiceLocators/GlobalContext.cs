using ACS.Core.ServicesContainer;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Systems.Brain;
using InternalAssets.Codebase.Gameplay.Generators.Variations.CatsGenerating;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Gameplay.Workplaces.Service;
using InternalAssets.Codebase.Library.MonoEntity.Tools.World;

namespace InternalAssets.Codebase.ServiceLocators
{
    public class GlobalContext : ServiceContainerGlobal
    {
        protected override void Bootstrap()
        {
            base.Bootstrap();

            Container.Register(typeof(EntityWorld), new EntityWorld());
            Container.Register(typeof(WorkplaceService), new WorkplaceService());
            Container.Register(typeof(CatGenerator), new CatGenerator());
            Container.Register(typeof(INavigationService), new NavigationService());
            Container.Register(typeof(CatsBrainSystem), new CatsBrainSystem());
        }
    }
}
