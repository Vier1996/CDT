using InternalAssets.Codebase.Gameplay.Enums;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Gameplay.Relaxes;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Cats.BehaviorTypes.Relaxing
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
            _catAnimator.SetAnimation(CatAnimationType.rest_lie_to, completeCallback: OnLie);
        }
        
        private void OnLie()
        {
            _catAnimator.SetAnimation(CatAnimationType.rest_sleep_to, completeCallback: OnSleep);
        }
        
        private void OnSleep()
        {
            _catAnimator.SetAnimation(CatAnimationType.rest_sleep_idle);
        }

        public override void Exit()
        {
            _translateComponent.StopTranslate();
        }
    }
}