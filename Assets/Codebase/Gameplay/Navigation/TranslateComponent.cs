using System;
using Codebase.Library.Extension;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

namespace Codebase.Gameplay.Navigation
{
    public class TranslateComponent : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agentOfEnenty;

        private IDisposable _navigationDisposable;

        public void Translate(Transform targetTransform, bool force = false, Action completeCallback = null) => 
            Translate(targetTransform.position, force, completeCallback);

        public void Translate(Vector3 targetPosition, bool force = false, Action completeCallback = null)
        {
            if (force) _navigationDisposable?.Dispose();
            
            if(_navigationDisposable != null) return;
            
            completeCallback += OnArrived;
            
            _navigationDisposable = _agentOfEnenty.MoveTo(targetPosition, completeCallback: completeCallback).Subscribe();
        }

        public void StopTranslate() => OnArrived();

        private void OnArrived()
        {
            _navigationDisposable?.Dispose();
            _navigationDisposable = null;
        }
    }
}
