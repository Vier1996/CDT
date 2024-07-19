using ACS.Core.ServicesContainer;

using UnityEngine;

namespace InternalAssets.Codebase.ServiceLocators
{
    public class LocalContext : ServiceContainerLocal
    {
        [SerializeField] private Camera _camera;
        
        protected override void Bootstrap()
        {
            base.Bootstrap();

            Container.Register(typeof(Camera), _camera);
        }
    }
}
