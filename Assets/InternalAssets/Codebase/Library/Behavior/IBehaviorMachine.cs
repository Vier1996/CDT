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
        [field: OdinSerialize] public string BehaviorId { get; private set; }
        [field: OdinSerialize] public IBehaviorComponents Components { get; private set; }
        
        public BehaviorStateProperty(CatBehaviorType behaviorId, IBehaviorComponents components)
        {
            BehaviorId = behaviorId.ToString();
            Components = components;
        }
        
        public BehaviorStateProperty(string behaviorId, IBehaviorComponents components)
        {
            BehaviorId = behaviorId;
            Components = components;
        }
    }
}