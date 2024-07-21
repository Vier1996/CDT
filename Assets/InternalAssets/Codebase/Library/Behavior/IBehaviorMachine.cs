using System;
using InternalAssets.Codebase.Library.ExceptionExtension;
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
        [field: OdinSerialize] public Type BehaviorType { get; private set; }
        [field: OdinSerialize] public IBehaviorComponents Components { get; private set; }

        public BehaviorStateProperty(Type behaviorType, IBehaviorComponents components)
        {
            if (behaviorType.InheritsFrom(typeof(IBehavior)) == false)
                throw this.TypeCast<Type, IBehavior>();
            
            BehaviorType = behaviorType;
            Components = components;
        }
    }
}