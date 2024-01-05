using System;
using Codebase.Gameplay.Enums;
using Codebase.Library.Extension;
using Codebase.Library.Extension.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Codebase.Gameplay.Cats
{
    public class CatAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private IDisposable _disposable;
        
        private Action _callback;
        private CatAnimationType _currentAnimationType;
        
        private bool _isDisabled = false;
        
        [Button]
        public void SetAnimation(CatAnimationType catAnimationType, bool force = false, Action completeCallback = null)
        {
            if(catAnimationType == _currentAnimationType && force == false)
                return;

            if (_isDisabled)
            {
                _isDisabled = false;
                _animator.enabled = true;
            }

            _currentAnimationType = catAnimationType;
            _callback = completeCallback;
            
            _animator.StopPlayback();
            _animator.CrossFadeInFixedTime(_currentAnimationType.ToString(), fixedTransitionDuration: 0.2f, 0 ,0);

            catAnimationType.TryGetAttribute(out CatAnimationTypeAttribute attribute);

            _disposable?.Dispose();
            _disposable = RX.Delay(attribute.AnimationLength, OnAnimationCallback);
        }

        [Button]
        public void StopAnimator()
        {
            _isDisabled = true;
            _animator.enabled = false;
        }

        private void OnAnimationCallback()
        {
            _disposable?.Dispose();
            _callback?.Invoke();
        }
    }
}
