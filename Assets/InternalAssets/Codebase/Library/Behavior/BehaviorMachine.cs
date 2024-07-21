using System;
using System.Collections.Generic;
using System.Linq;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using UniRx;

namespace InternalAssets.Codebase.Library.Behavior
{
    public abstract class BehaviorMachine : IBehaviorMachine
    {
        public IReadOnlyReactiveProperty<IBehavior> StateChangedProperty => _stateChangedProperty;
        
        private readonly ReactiveProperty<IBehavior> _stateChangedProperty = new ();
        private readonly Dictionary<Type, IBehavior> _behaviorStates = new();
        private IBehavior _currentBehaviorState;
        
        public virtual void Dispose() => _currentBehaviorState?.Dispose();

        public void AppendBehavior(Type behaviorType, IBehavior behavior, EntityComponents components = null)
        {
            if(_behaviorStates.TryAdd(behaviorType, behavior))
                _behaviorStates.Last().Value.Construct(this, components);
        }

        public void ClearMachine()
        {
            _currentBehaviorState = null;
            _behaviorStates.Clear();
        }
        
        public void Notify(BehaviorStateProperty property)
        {
            if(TryChangeBehavior(property))
                _stateChangedProperty.Value = _currentBehaviorState;
        }

        private bool TryChangeBehavior(BehaviorStateProperty property)
        {
            _currentBehaviorState?.Exit();
            _currentBehaviorState = _behaviorStates[property.BehaviorType];
            _currentBehaviorState.Enter(property.Components);
            
            return true;
        }
    }
}