using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Gameplay.Entities.Base;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Enums;
using InternalAssets.Codebase.Library.Extension;
using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats
{
    public class CatAnimator : MonoBehaviour, IEntityAnimator
    {
        [SerializeField] private Animator _animator;
        
        private bool _isDisabled = false;
        private string _currentAnimationType;

        public async UniTask PlayAnimationAsTask(string animationType, bool force = false)
        {
            float duration = SetAnimation(animationType, force);
            
            if (duration < 0) return;
            
            await RX.DoValue(0f, duration, duration).ToUniTask();
        }

        public void PlayAnimation(string animationType, bool force = false)
        {
            SetAnimation(animationType, force);
        }

        private float SetAnimation(string animationType, bool force = false)
        {
            if(animationType.Equals(_currentAnimationType) && force == false)
                return -1f;
            
            if (_isDisabled)
            {
                _isDisabled = false;
                _animator.enabled = true;
            }

            _currentAnimationType = animationType;
            
            _animator.StopPlayback();
            _animator.CrossFadeInFixedTime(_currentAnimationType, fixedTransitionDuration: 0.2f, 0 ,0);

            return CatAnimationDurations.GetDuration(_currentAnimationType);
        }

        public void StopAnimator()
        {
            _isDisabled = true;
            _animator.enabled = false;
        }

        [Button] private void SetAnimationDebug(CatAnimationType animationType)
        {
            PlayAnimation(animationType.ToString(), true);
        }
    }
}
