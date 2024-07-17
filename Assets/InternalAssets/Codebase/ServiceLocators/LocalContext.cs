using ACS.Core.ServicesContainer;
using InternalAssets.Codebase.Gameplay.Behaviors;
using InternalAssets.Codebase.Gameplay.Workplaces;
using UnityEngine;

namespace InternalAssets.Codebase.ServiceLocators
{
    public class LocalContext : ServiceContainerLocal
    {
        [SerializeField] private Camera _camera;
        
        protected override void Bootstrap()
        {
            base.Bootstrap();

            Container.Register(typeof(BehaviorService), new BehaviorService());
            Container.Register(typeof(Camera), _camera);
        }
    }
}
