using System;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Enums;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.ExceptionExtension;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using UniRx;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior.BehaviorTypes.Transition
{
    public class CatTransitionToPointBehavior : CatBehaviorState
    {
        private IDisposable _subscriptionToStateDisposable;
        private CatAnimator _catAnimator;
        private TranslateComponent _translateComponent;
        private TransitionBehaviorComponents _transitionBehaviorComponents;
        
        public CatTransitionToPointBehavior(CatTransitionToPointBehavior other) => IsDefaultBehavior = other.IsDefaultBehavior;

        public override void Construct(EntityComponents components)
        {
            EntityComponents = components;

            EntityComponents.TryGetAbstractComponent(out CatEntity catEntity);
            EntityComponents.TryGetAbstractComponent(out _catAnimator);
            EntityComponents.TryGetAbstractComponent(out _translateComponent);

            _subscriptionToStateDisposable = catEntity.StateChangedProperty.Subscribe(OnStateChanged);
        }
        
        public override void Dispose() => _subscriptionToStateDisposable?.Dispose();

        private void OnStateChanged(ICatState state)
        {
            if (state is not ToTransitionState transitionState) return;
            
            Enter(new TransitionBehaviorComponents(transitionState.Target, transitionState.Reason));
        }

        protected override void Enter(BehaviorComponents behaviorComponents = null)
        {
            _transitionBehaviorComponents = behaviorComponents as TransitionBehaviorComponents;

            if (_transitionBehaviorComponents is null) 
                throw new ArgumentException(ExceptionMessages.Cast<BehaviorComponents, TransitionBehaviorComponents>());
            
            _catAnimator.SetAnimation(CatAnimationType.move_run_f, force: true);
            
            _translateComponent.Translate(
                targetTransform: _transitionBehaviorComponents.Target,
                completeCallback: Exit);
        }

        protected override void Exit()
        {
            _transitionBehaviorComponents.Reason.CompleteEvent?.Invoke();
        }
    }

    public class TransitionBehaviorComponents : BehaviorComponents
    {
        public Transform Target;
        public ICatTransitionReason Reason;

        public TransitionBehaviorComponents(Transform target, ICatTransitionReason reason)
        {
            Target = target;
            Reason = reason;
        }
    }
}