using Codebase.Gameplay.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Codebase.Gameplay.Cats
{
    public class CatAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private CatAnimationType _currentAnimationType;
        private bool _isDisabled = false;
        
        [Button]
        public void SetAnimation(CatAnimationType catAnimationType, bool force = false)
        {
            if(catAnimationType == _currentAnimationType && force == false)
                return;

            if (_isDisabled)
            {
                _isDisabled = false;
                _animator.enabled = true;
            }

            _currentAnimationType = catAnimationType;
            
            _animator.StopPlayback();
            _animator.CrossFadeInFixedTime(_currentAnimationType.ToString(), fixedTransitionDuration: 0.2f, 0 ,0);
        }

        [Button]
        public void StopAnimator()
        {
            _isDisabled = true;
            _animator.enabled = false;
        }
    }
}
