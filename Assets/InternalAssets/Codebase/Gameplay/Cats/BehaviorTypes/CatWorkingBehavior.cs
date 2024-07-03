using InternalAssets.Codebase.Gameplay.Enums;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Gameplay.Workplaces;
using InternalAssets.Codebase.Library.Behaviors;
using InternalAssets.Codebase.Library.Extension;
using InternalAssets.Codebase.Library.MonoEntity.Entities;

namespace InternalAssets.Codebase.Gameplay.Cats.BehaviorTypes
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
                _catWorkingBehaviorComponents.Workplace.WorkplaceComponents.WorkingTransform, 
                completeCallback: OnArrivedToWorkplace);
        }

        private void OnArrivedToWorkplace()
        {
            _catAnimator.SetAnimation(CatAnimationType.action_coding_begin, completeCallback: OnCodingBegin);
            
            _catEntity.Transform.Normalize(_catWorkingBehaviorComponents.Workplace.WorkplaceComponents.ModelTransform);
        }

        private void OnCodingBegin()
        {
            //_catWorkingBehaviorComponents.Workplace.
            _catAnimator.SetAnimation(CatAnimationType.action_coding_loop);
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