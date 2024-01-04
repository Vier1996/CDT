using System;
using System.Collections.Generic;
using Codebase.Gameplay.Cats.BehaviorTypes;
using Codebase.Gameplay.Workers;
using Codebase.Library.Behaviors;

namespace Codebase.Gameplay.Cats
{
    public class CatEntity : Worker, IBehaviorSwitcher
    {
        private CatBehaviorState _currentBehaviorState;
        
        private Dictionary<Type, CatBehaviorState> _behaviorStates = new Dictionary<Type, CatBehaviorState>();
        
        public void SwitchBehavior<TBehavior>(Action onComplete = null, bool force = false) where TBehavior : IBehavior
        {
            
        }

        public void Initialize()
        {
            InitializeStates();
        }
        
        private void InitializeStates()
        {
            _behaviorStates.Add(typeof(CatIdleBehavior), new CatIdleBehavior());
            _behaviorStates.Add(typeof(CatWalkBehavior), new CatWalkBehavior());
        }
    }
}