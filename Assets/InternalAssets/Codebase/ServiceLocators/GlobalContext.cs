using ACS.Core.ServicesContainer;
using InternalAssets.Codebase.Library.MonoEntity.Tools.World;

namespace InternalAssets.Codebase.ServiceLocators
{
    public class GlobalContext : ServiceContainerGlobal
    {
        protected override void Bootstrap()
        {
            base.Bootstrap();

            Container.Register(typeof(EntityWorld), new EntityWorld());
        }
    }
}
