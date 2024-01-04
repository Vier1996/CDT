using UnityEngine;

namespace Codebase.Library.ServiceContainer
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ServiceLocator))]
    public abstract class Bootstrapper : MonoBehaviour
    {
        private ServiceLocator container;
        internal ServiceLocator Container => container ??= container = GetComponent<ServiceLocator>();

        private bool hasBeenBootstrapped;

        private void Awake()
        {
            BootstrapOnDemand();
        }

        public void BootstrapOnDemand()
        {
            if(hasBeenBootstrapped) return;

            hasBeenBootstrapped = true;

            Bootstrap();
        }

        protected abstract void Bootstrap();
    }
}