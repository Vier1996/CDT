using Codebase.Gameplay.Enums;
using Codebase.Gameplay.Navigation;
using Codebase.Gameplay.Relaxes;
using Codebase.Library.Extension;
using UnityEngine;

namespace Codebase.Gameplay.Cats.BehaviorTypes.Relaxing
{
    public class CatSleepingZoneSubBehavior : CatRelaxingSubBehavior
    {
        private SleepingZone _sleepingZone;
        private TranslateComponent _translateComponent;
        private CatAnimator _catAnimator;
        public CatSleepingZoneSubBehavior(RelaxPoint relaxPoint, CatComponents catComponents) : base(relaxPoint, catComponents)
        {
            _sleepingZone = RelaxPoint as SleepingZone;
            
            CatComponents.TryGetAbstractComponent(out _translateComponent);
            CatComponents.TryGetAbstractComponent(out _catAnimator);
        }
        
        public override void Enter()
        {
            MoveToSleepingPoint();
        }

        private void MoveToSleepingPoint()
        {
            Vector3 sleepingPoint = _sleepingZone.SleepingPoint;
            
            _catAnimator.SetAnimation(CatAnimationType.move_run_f);
            _translateComponent.Translate(sleepingPoint, completeCallback: OnArrivedToSleepingPoint);
        }

        private void OnArrivedToSleepingPoint()
        {
            _catAnimator.SetAnimation(CatAnimationType.rest_lie_to);

            RX.Delay(1.5f, OnLie);
        }
        
        private void OnLie()
        {
            _catAnimator.SetAnimation(CatAnimationType.rest_sleep_to);

            RX.Delay(1.5f, OnSleep);
        }
        
        private void OnSleep()
        {
            
        }

        public override void Exit()
        {
        }
    }
}