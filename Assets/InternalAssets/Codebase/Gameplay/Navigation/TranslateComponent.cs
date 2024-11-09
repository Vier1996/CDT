using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Library.Async;
using InternalAssets.Codebase.Library.Extension;
using UnityEngine;
using UnityEngine.AI;

namespace InternalAssets.Codebase.Gameplay.Navigation
{
    public class TranslateComponent : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agentOfEnenty;

        private bool _isBusy = false;
        
        public async UniTask Translate(Vector3 targetPosition, bool force = false)
        {
            if (_isBusy && force == false) return;

            _isBusy = true;

            try
            {
                await _agentOfEnenty
                    .MoveTo(targetPosition)
                    .ToUniTask(cancellationToken: this.GetCancellationTokenOnDestroy());
            }
            catch (OperationCanceledException e)
            {
                return;
            }
            
            _isBusy = false;
        }
    }
}
