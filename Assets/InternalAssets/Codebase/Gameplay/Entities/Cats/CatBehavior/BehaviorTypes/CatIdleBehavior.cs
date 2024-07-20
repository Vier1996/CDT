using System;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Enums;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using UniRx;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior.BehaviorTypes
{
    public class CatIdleBehavior : CatBehaviorState
    {
        private IDisposable _subscriptionToStateDisposable;
        private CatAnimator _catAnimator;
        
        public CatIdleBehavior(CatIdleBehavior other) => IsDefaultBehavior = other.IsDefaultBehavior;

        public override void Construct(EntityComponents components)
        {
            EntityComponents = components;

            EntityComponents.TryGetAbstractComponent(out CatEntity catEntity);
            EntityComponents.TryGetAbstractComponent(out _catAnimator);
            
            _subscriptionToStateDisposable = catEntity.StateChangedProperty.Subscribe(OnStateChanged);
        }
        
        private void OnStateChanged(ICatState state)
        {
            if (state is not ToIdleState transitionState) return;
            
            Enter();
        }

        protected override void Enter(BehaviorComponents behaviorComponents = null)
        {
            _catAnimator.SetAnimation(CatAnimationType.idle_base, force: true);
        }

        protected override void Exit()
        {
        }
    }
}