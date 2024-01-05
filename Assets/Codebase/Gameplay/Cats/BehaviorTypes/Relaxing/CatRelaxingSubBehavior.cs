using Codebase.Gameplay.Relaxes;

namespace Codebase.Gameplay.Cats.BehaviorTypes.Relaxing
{
    public abstract class CatRelaxingSubBehavior
    {
        protected RelaxPoint RelaxPoint;
        protected CatComponents CatComponents;

        public CatRelaxingSubBehavior(RelaxPoint relaxPoint, CatComponents catComponents)
        {
            RelaxPoint = relaxPoint;
            CatComponents = catComponents;
        }

        public abstract void Enter();
        
        public abstract void Exit();
    }
}