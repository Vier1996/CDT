using InternalAssets.Codebase.Gameplay.Enums;
using InternalAssets.Codebase.Library.Behaviors;

namespace InternalAssets.Codebase.Gameplay.Cats.BehaviorTypes
{
    public class CatIdleBehavior : CatBehaviorState
    {
        public CatIdleBehavior(CatComponents catComponents) : base(catComponents)
        {
        }
        
        public override void Enter(BehaviorComponents behaviorComponents = null)
        {
            CatComponents.TryGetAbstractComponent(out CatAnimator catAnimator);
            
            catAnimator.SetAnimation(CatAnimationType.idle_base);
        }
        
        public override void Exit()
        {
        }
    }
}