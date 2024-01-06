using Codebase.Gameplay.Relaxes;
using Codebase.Library.Behaviors;

namespace Codebase.Gameplay.Cats.BehaviorTypes.Relaxing
{
    public class CatRelaxingBehavior : CatBehaviorState
    {
        private CatRelaxingBehaviorComponents _catRelaxingBehaviorComponents;
        private CatRelaxingSubBehavior _currentSubBehavior;
        
        public CatRelaxingBehavior(CatComponents catComponents) : base(catComponents) { }
        
        public override void Enter(BehaviorComponents behaviorComponents = null)
        {
            _catRelaxingBehaviorComponents = behaviorComponents as CatRelaxingBehaviorComponents;

            if(_catRelaxingBehaviorComponents == null)
                return;
            
            switch (_catRelaxingBehaviorComponents.RelaxPoint)
            {
                case SleepingZone:
                    _currentSubBehavior = new CatSleepingZoneSubBehavior(_catRelaxingBehaviorComponents.RelaxPoint, CatComponents);
                    break;
            }

            _currentSubBehavior?.Enter();
        }
        
        public override void Exit()
        {
            _currentSubBehavior?.Exit();
            _currentSubBehavior = null;
        }
    }

    public class CatRelaxingBehaviorComponents : BehaviorComponents
    {
        public RelaxPoint RelaxPoint;
    }
}