using System.Collections.Generic;

namespace Codebase.Library.SAD
{
    public abstract class EntityComponents
    {
        protected Dictionary<string, object> innerComponents = new Dictionary<string, object>();

        public abstract EntityComponents Declare(Entity abstractEntity);
        
        public bool TryGetAbstractComponent<T>(out T component, string postfix = "")
        {
            string targetType = typeof(T).Name + postfix;
            bool containsComponent = innerComponents.TryGetValue(targetType, out object innerComponent);
            
            component = containsComponent ? (T)innerComponent : default;

            return containsComponent;
        }
    }
}