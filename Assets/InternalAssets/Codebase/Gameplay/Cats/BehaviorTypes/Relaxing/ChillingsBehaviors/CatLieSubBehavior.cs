using System;
using InternalAssets.Codebase.Gameplay.Enums;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Gameplay.Relaxes;
using InternalAssets.Codebase.Library.Extension;
using InternalAssets.Codebase.Library.Random;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Cats.BehaviorTypes.Relaxing.ChillingsBehaviors
{
    public class CatLieSubBehavior : CatRelaxingSubBehavior
    {
        private IDisposable _workingDisposable;
        private ChillingZone _chillingZone;
        private TranslateComponent _translateComponent;
        private CatAnimator _catAnimator;
        private CatEntity _catEntity;
        
        public CatLieSubBehavior(RelaxPoint relaxPoint, CatComponents catComponents) : base(relaxPoint, catComponents)
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
            _catAnimator.SetAnimation(CatAnimationType.rest_lie_to, completeCallback: () =>
            {
                LaunchWorkTimer();

                _catAnimator.SetAnimation(CatAnimationType.rest_lie_idle);
            });
        }

        private void LaunchWorkTimer()
        {
            _workingDisposable?.Dispose();
            _workingDisposable = RX.Delay(5f, TryReUpdateSubBehavior);
        }

        private void TryReUpdateSubBehavior()
        {
            if (WeightRandom.DoChance(50))
            {
                LaunchWorkTimer();
                return;
            }

            TryAnotherChilling();
        }

        private void TryAnotherChilling() => _catEntity.TryChangeRelaxing();

        public override void Exit()
        {
            _workingDisposable?.Dispose();
            _workingDisposable = null;
            
            _translateComponent.StopTranslate();
        }
    }
}