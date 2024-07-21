using System;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Enums;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.ExceptionExtension;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior.BehaviorTypes.Transition
{
    public class CatTransitionToPointBehavior : CatBehaviorState
    {
        private CatAnimator _catAnimator;
        private TranslateComponent _translateComponent;
        private TransitionBehaviorComponents _transitionBehaviorComponents;
        
        public CatTransitionToPointBehavior(CatTransitionToPointBehavior other) => IsDefaultBehavior = other.IsDefaultBehavior;

        public override void Construct(IBehaviorMachine machine, EntityComponents components)
        {
            EntityComponents = components;
            EntityComponents.TryGetAbstractComponent(out _catAnimator);
            EntityComponents.TryGetAbstractComponent(out _translateComponent);
        }

        public override void Enter(IBehaviorComponents behaviorComponents = null)
        {
            _transitionBehaviorComponents = behaviorComponents as TransitionBehaviorComponents;

            if (_transitionBehaviorComponents is null) 
                throw this.TypeCast<IBehaviorComponents, TransitionBehaviorComponents>();
            
            _catAnimator.SetAnimation(CatAnimationType.move_run_f, force: true);
            
            _translateComponent.Translate(
                targetTransform: _transitionBehaviorComponents.Target,
                completeCallback: Exit);
        }

        public override void Exit()
        {
            _transitionBehaviorComponents?.Reason?.CompleteEvent?.Invoke();
        }
    }

    [Serializable]
    public class TransitionBehaviorComponents : IBehaviorComponents
    {
        public readonly Transform Target;
        public readonly ICatTransitionReason Reason;

        public TransitionBehaviorComponents(Transform target, ICatTransitionReason reason)
        {
            Target = target;
            Reason = reason;
        }
    }
}