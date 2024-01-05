using Codebase.Gameplay.Enums;
using Codebase.Library.Behaviors;

namespace Codebase.Gameplay.Cats.BehaviorTypes
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