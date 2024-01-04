using UnityEngine;

namespace Codebase.Library.ServiceContainer
{
    [AddComponentMenu("ServiceLocator/ServiceLocator Global")]
    public class ServiceLocatorGlobalBootstrapper : Bootstrapper
    {
        [SerializeField] private bool dontDestroyOnLoad = true;
        
        protected override void Bootstrap()
        {
            Container.ConfigureAsGlobal(dontDestroyOnLoad);
        }
    }
}