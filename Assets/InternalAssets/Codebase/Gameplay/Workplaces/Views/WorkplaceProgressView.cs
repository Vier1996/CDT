using System;
using UniRx;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Workplaces.Views
{
    public class WorkplaceProgressView : MonoBehaviour
    {
        private IDisposable _reactiveDisposable;
        private Transform _transform;
        private Workplace _currentWorkplace;
        
        private bool _isEnabled = false;

        private void Awake()
        {
            _transform = transform;
        }

        public void Initialize(Workplace workplace)
        {
            _currentWorkplace = workplace;
        }

        public void Display()
        {
            _reactiveDisposable?.Dispose();
            _reactiveDisposable = _currentWorkplace.WorkCompleteProgress.Subscribe(UpdateProgress);
        }
        
        public void Hide()
        {
            _reactiveDisposable?.Dispose();
        }
        
        private void UpdateProgress(float progress)
        {
            
        }
    }
}