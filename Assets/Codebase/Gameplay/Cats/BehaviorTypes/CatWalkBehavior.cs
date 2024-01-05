using Codebase.Library.Behaviors;

namespace Codebase.Gameplay.Cats.BehaviorTypes
{
    public class CatWalkBehavior : CatBehaviorState
    {
        public CatWalkBehavior(CatComponents catComponents) : base(catComponents)
        {
            
        }
        
        public override void Enter(BehaviorComponents behaviorComponents = null)
        {
        }
        
        public override void Exit()
        {
        }
    }
}