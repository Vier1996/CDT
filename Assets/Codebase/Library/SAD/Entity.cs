using Codebase.Library.ServiceContainer;
using UnityEngine;

namespace Codebase.Library.SAD
{
    public abstract class Entity : MonoBehaviour
    {
        public Transform Transform { get; private set; }
        
        private EntityComponents _components = new DefaultEntityComponents();
        protected EntityWorld _entityWorld;
        
        protected void BindComponents(EntityComponents components)
        {
            _components = components.Declare(this);

            Transform = transform;
        }

        public virtual void Initialize()
        {
            ServiceLocator.For(this).Get(out _entityWorld);
            
            _entityWorld.AddEntity(this);
        }

        public bool TryGetAbstractComponent<T>(out T component, string postfix = "")
        {
            if (_components.TryGetAbstractComponent(out T receivedComponent, postfix))
            {
                component = receivedComponent;
                return true;
            }

            component = default;
            return false;
        }
    }
}