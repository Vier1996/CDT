using System;
using System.Collections.Generic;
using System.Linq;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;

namespace InternalAssets.Codebase.Library.Behavior
{
    public class BehaviorMachine
    {
        private readonly Dictionary<Type, IBehavior> _behaviorStates = new();
        private IBehavior _currentBehaviorState;

        public BehaviorMachine AppendBehavior(Type behaviorType, IBehavior behavior, EntityComponents components = null)
        {
            if(_behaviorStates.TryAdd(behaviorType, behavior))
                _behaviorStates.Last().Value.Construct(components);
            
            return this;
        }

        public void ClearMachine()
        {
            _currentBehaviorState = null;
            _behaviorStates.Clear();
        }
        
        public void Dispose() => _currentBehaviorState?.Dispose();
    }
}