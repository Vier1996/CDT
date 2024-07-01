using InternalAssets.Codebase.Gameplay.Enums;
using InternalAssets.Codebase.Library.Behaviors;

namespace InternalAssets.Codebase.Gameplay.Cats.BehaviorTypes
{
    public class CatRunBehavior : CatBehaviorState
    {
        public CatRunBehavior(CatComponents catComponents) : base(catComponents)
        {
            
        }
        
        public override void Enter(BehaviorComponents behaviorComponents = null)
        {
            CatComponents.TryGetAbstractComponent(out CatAnimator catAnimator);
            
            catAnimator.SetAnimation(CatAnimationType.move_run_f);
        }
        
        public override void Exit()
        {
        }
    }
}