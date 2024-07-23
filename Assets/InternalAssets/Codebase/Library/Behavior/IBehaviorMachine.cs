using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior;
using InternalAssets.Codebase.Library.ExceptionExtension;
using InternalAssets.Codebase.Library.Reflection;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Sirenix.Utilities;
using UniRx;

namespace InternalAssets.Codebase.Library.Behavior
{
    public interface IBehaviorMachine
    {
        public IReadOnlyReactiveProperty<IBehavior> StateChangedProperty { get; }

        public void Notify(BehaviorStateProperty property);
    }

    [Serializable]
    public class BehaviorStateProperty
    {
        [field: OdinSerialize, ValueDropdown(nameof(GetSubTypes))] public Type BehaviorType { get; private set; }
        [field: OdinSerialize] public IBehaviorComponents Components { get; private set; }
        
        public BehaviorStateProperty(Type behaviorType, IBehaviorComponents components)
        {
            if (behaviorType.InheritsFrom(typeof(IBehavior)) == false)
                throw this.TypeCast<Type, IBehavior>();
            
            BehaviorType = behaviorType;
            Components = components;
        }

        //private IEnumerable<Type> GetSubTypes<T>() => typeof(T).GetAllInheritsTypes();
        private IEnumerable<Type> GetSubTypes() => typeof(CatBehaviorState).GetAllInheritsTypes();
    }
}