using Codebase.Gameplay.Enums;
using Codebase.Library.Behaviors;

namespace Codebase.Gameplay.Cats.BehaviorTypes
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