using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Library.Extension;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.CompositeOperations.Variations
{
    [Serializable]
    public class RotateToTransformOperation : ICompositeOperation
    {
        [SerializeField] private bool _isAwait = true;
        [SerializeField] private float _rotateDuration;
        [SerializeField] private Transform _target;
        
        public async UniTask Execute(Entity entity, CancellationToken cancellationToken)
        {
            Vector3 targetLookingPosition = new Vector3(_target.position.x, entity.Transform.position.y, _target.position.z);

            if (_isAwait == false)
            {
                entity
                    .Transform
                    .DOLookAt(targetLookingPosition, _rotateDuration, AxisConstraint.X, Vector3.up)
                    .SetEase(Ease.Linear);
                
                return;
            }
            try
            {
                await entity
                    .Transform
                    .DOLookAt(targetLookingPosition, _rotateDuration, AxisConstraint.None, Vector3.up)
                    .SetEase(Ease.Linear)
                    .ToUniTask(cancellationToken);
            }
            catch (OperationCanceledException e) { return; }
        }
    }
}