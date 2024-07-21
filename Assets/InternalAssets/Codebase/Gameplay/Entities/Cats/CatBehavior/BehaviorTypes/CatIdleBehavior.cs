using InternalAssets.Codebase.Gameplay.Entities.Cats.Enums;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior.BehaviorTypes
{
    public class CatIdleBehavior : CatBehaviorState
    {
        private CatAnimator _catAnimator;
        
        public CatIdleBehavior(CatIdleBehavior other) => IsDefaultBehavior = other.IsDefaultBehavior;

        public override void Construct(IBehaviorMachine machine, EntityComponents components)
        {
            EntityComponents = components;
            EntityComponents.TryGetAbstractComponent(out _catAnimator);
        }

        public override void Enter(IBehaviorComponents behaviorComponents = null)
        {
            _catAnimator.SetAnimation(CatAnimationType.idle_base, force: true);
        }

        public override void Exit()
        {
        }
    }
}