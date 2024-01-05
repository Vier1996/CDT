using System;
using System.Collections.Generic;

namespace Codebase.Library.Behaviors
{
    public class BehaviorMachine
    {
        private Dictionary<Type, IBehavior> _behaviorStates = new Dictionary<Type, IBehavior>();
        private IBehavior _currentBehaviorState;

        public BehaviorMachine AppendBehavior(Type behaviorType, IBehavior behavior)
        {
            _behaviorStates.TryAdd(behaviorType, behavior);
            
            return this;
        }
        
        public void SwitchBehavior<TBehavior>(BehaviorComponents behaviorComponents = null, bool force = false) where TBehavior : IBehavior
        {
            IBehavior nextBehavior = _behaviorStates[typeof(TBehavior)];
            
            if(_currentBehaviorState == nextBehavior && force == false)
                return;
            
            _currentBehaviorState?.Exit();
            _currentBehaviorState = nextBehavior;
            _currentBehaviorState.Enter(behaviorComponents);
        }
    }
}