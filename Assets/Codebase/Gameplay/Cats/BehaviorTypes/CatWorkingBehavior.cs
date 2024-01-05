using Codebase.Gameplay.Enums;
using Codebase.Gameplay.Navigation;
using Codebase.Gameplay.Workplaces;
using Codebase.Library.Behaviors;
using Codebase.Library.Extension;
using Codebase.Library.SAD;
using UnityEngine;

namespace Codebase.Gameplay.Cats.BehaviorTypes
{
    public class CatWorkingBehavior : CatBehaviorState
    {
        private CatWorkingBehaviorComponents _catWorkingBehaviorComponents;
        private TranslateComponent _translateComponent;
        private CatAnimator _catAnimator;
        private Entity _catEntity;

        public CatWorkingBehavior(CatComponents catComponents) : base(catComponents)
        {
            CatComponents.TryGetAbstractComponent(out _translateComponent);
            CatComponents.TryGetAbstractComponent(out _catAnimator);
            CatComponents.TryGetAbstractComponent(out _catEntity);
        }
        
        public override void Enter(BehaviorComponents behaviorComponents = null)
        {
            _catWorkingBehaviorComponents = behaviorComponents as CatWorkingBehaviorComponents;

            TryMoveToWorkplace();
        }
        
        private void TryMoveToWorkplace()
        {
            _catAnimator.SetAnimation(CatAnimationType.move_run_f);

            _translateComponent.Translate(
                _catWorkingBehaviorComponents.Workplace.WorkplaceStandingTransform, 
                completeCallback: OnArrivedToWorkplace);
        }

        private void OnArrivedToWorkplace()
        {
            _catAnimator.SetAnimation(CatAnimationType.idle_base);
            
            _catEntity.Transform.Normalize(_catWorkingBehaviorComponents.Workplace.Origin);
        }
        
        public override void Exit()
        {
        }
    }

    public class CatWorkingBehaviorComponents : BehaviorComponents
    {
        public Workplace Workplace;
    }
}