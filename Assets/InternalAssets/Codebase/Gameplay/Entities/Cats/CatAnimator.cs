using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Enums;
using InternalAssets.Codebase.Library.ExceptionExtension;
using InternalAssets.Codebase.Library.Extension;
using InternalAssets.Codebase.Library.Extension.Reflection;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats
{
    public class CatAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private bool _isDisabled = false;
        private CatAnimationType _currentAnimationType;

        public async UniTask PlayAnimationAsTask(CatAnimationType catAnimationType, bool force = false)
        {
            CatAnimationTypeAttribute attribute = SetAnimation(catAnimationType, force);
            
            if(attribute == null)
                return;
            
            await RX.DoValue(0f, attribute.AnimationLength, attribute.AnimationLength).ToUniTask();
        }

        public void PlayAnimation(CatAnimationType catAnimationType, bool force = false)
        {
            SetAnimation(catAnimationType, force);
        }

        private CatAnimationTypeAttribute SetAnimation(CatAnimationType catAnimationType, bool force = false)
        {
            if(catAnimationType == _currentAnimationType && force == false)
                return null;
            
            if (_isDisabled)
            {
                _isDisabled = false;
                _animator.enabled = true;
            }

            _currentAnimationType = catAnimationType;
            
            _animator.StopPlayback();
            _animator.CrossFadeInFixedTime(_currentAnimationType.ToString(), fixedTransitionDuration: 0.2f, 0 ,0);

            catAnimationType.TryGetAttribute(out CatAnimationTypeAttribute attribute);

            if (attribute == null)
                throw this.MissedAttribute<CatAnimationTypeAttribute>();

            return attribute;
        }

        [Button]
        public void StopAnimator()
        {
            _isDisabled = true;
            _animator.enabled = false;
        }
    }
}
