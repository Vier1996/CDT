using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.CompositeOperations.Variations
{
    [Serializable]
    public class DelayOperation : ICompositeOperation
    {
        [SerializeField] private float _delay;
        
        public async UniTask Execute(Entity entity, CancellationToken cancellationToken)
        {
            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(_delay), cancellationToken: cancellationToken);
            }
            catch (OperationCanceledException e) { return; }
        }
    }
}