using InternalAssets.Codebase.Gameplay.Entities.Cats.Enums;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior.BehaviorTypes
{
    public class CatRunBehavior : CatBehaviorState
    {
        private CatAnimator _catAnimator;

        public CatRunBehavior(CatRunBehavior other) => IsDefaultBehavior = other.IsDefaultBehavior;

        public override void Construct(EntityComponents components)
        {
            EntityComponents = components;
            
            EntityComponents.TryGetAbstractComponent(out _catAnimator);
        }

        protected override void Enter(BehaviorComponents behaviorComponents = null)
        {
            _catAnimator.SetAnimation(CatAnimationType.move_walk_f, force: true);
        }

        protected override void Exit()
        {
        }
    }
}