using InternalAssets.Codebase.Gameplay.Enums;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Gameplay.Relaxes;
using InternalAssets.Codebase.Library.Random;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Cats.BehaviorTypes.Relaxing.ChillingsBehaviors
{
    public class CatWashingSubBehavior : CatRelaxingSubBehavior
    {
        private ChillingZone _chillingZone;
        private TranslateComponent _translateComponent;
        private CatAnimator _catAnimator;
        private CatEntity _catEntity;
        
        public CatWashingSubBehavior(RelaxPoint relaxPoint, CatComponents catComponents) : base(relaxPoint, catComponents)
        {
            _chillingZone = RelaxPoint as ChillingZone;

            CatComponents.TryGetAbstractComponent(out _translateComponent);
            CatComponents.TryGetAbstractComponent(out _catAnimator);
            CatComponents.TryGetAbstractComponent(out _catEntity);
        }

        public override void Enter()
        {
            MoveToChillingPosition();
        }

        private void MoveToChillingPosition()
        {
            bool inBounds = _chillingZone.InBounds(_catEntity.Transform.position);
            
            if (inBounds && WeightRandom.DoChance(33) || inBounds == false)
            {
                Vector3 sleepingPoint = _chillingZone.ChillingPoint;
            
                _catAnimator.SetAnimation(CatAnimationType.move_run_f);
                _translateComponent.Translate(sleepingPoint, completeCallback: OnArrivedToChillingPoint);
                
                return;
            }

            OnArrivedToChillingPoint();
        }
        
        private void OnArrivedToChillingPoint()
        {
            _catAnimator.SetAnimation(CatAnimationType.action_licking_sit, 
                completeCallback: () => _catAnimator.SetAnimation(CatAnimationType.action_shaking, 
                    completeCallback: TryAnotherChilling));
        }

        private void TryAnotherChilling() => _catEntity.TryChangeRelaxing();
        
        public override void Exit()
        {
            _translateComponent.StopTranslate();
        }
    }
}