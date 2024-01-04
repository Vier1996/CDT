using Codebase.Library.Behaviors;

namespace Codebase.Gameplay.Cats
{
    public abstract class CatBehaviorState : IBehavior
    {
        public CatBehaviorState() { }
        
        public virtual void Enter() { }

        public virtual void Exit() { }
    }
}