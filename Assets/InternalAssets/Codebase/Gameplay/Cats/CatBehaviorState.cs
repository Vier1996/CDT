using InternalAssets.Codebase.Library.Behaviors;

namespace InternalAssets.Codebase.Gameplay.Cats
{
    public abstract class CatBehaviorState : IBehavior
    {
        protected CatComponents CatComponents;
        public CatBehaviorState(CatComponents catComponents) => CatComponents = catComponents;
        
        public virtual void Enter(BehaviorComponents behaviorComponents = null) { }

        public virtual void Exit() { }
    }
}