using System;
using InternalAssets.Codebase.Gameplay.Workplaces.Base;
using InternalAssets.Codebase.Library.Extension;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace InternalAssets.Codebase.Gameplay.Workplaces.Views
{
    public class WorkplaceProgressView : MonoBehaviour
    {
        [BoxGroup("Transforms"), SerializeField] private Transform _parentTransform;
        [BoxGroup("Transforms"), SerializeField] private Transform _clockTransform;
        [BoxGroup("General"), SerializeField] private Image _progressImage;
        
        private IDisposable _reactiveDisposable;
        private Transform _transform;
        private Workplace _currentWorkplace;
        
        private bool _isEnabled = false;

        private void Awake() => _transform = transform;

        public WorkplaceProgressView Subscribe(Workplace workplace)
        {
            _currentWorkplace = workplace;
            
            _reactiveDisposable?.Dispose();
            _reactiveDisposable = _currentWorkplace.WorkProgress.Subscribe(UpdateProgress);
            
            return this;
        }

        public WorkplaceProgressView Unsubscribe()
        {
            _reactiveDisposable?.Dispose();
            
            return this;
        }

        [Button] public void Display(float duration = 0.4f)
        {
            if (duration <= 0f)
            {
                _parentTransform.localScale = Vector3.one;
                return;
            }
            
            _parentTransform.DisplayTaptic(_clockTransform, duration).Forget();
        }
        
        [Button] public void Hide(float duration = 0.4f)
        {
            if (duration <= 0f)
            {
                _parentTransform.localScale = Vector3.zero;
                return;
            }
            
            _parentTransform.HideTaptic(_clockTransform, duration).Forget();
        }
        
        private void UpdateProgress(float progress)
        {
            _progressImage.fillAmount = progress;
        }
    }
}