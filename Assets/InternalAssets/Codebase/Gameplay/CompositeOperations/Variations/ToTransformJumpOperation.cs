using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using InternalAssets.Codebase.Library.Extension;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.CompositeOperations.Variations
{
    [Serializable]
    public class ToTransformJumpOperation : ICompositeOperation
    {
        [SerializeField] private float _jumpPower;
        [SerializeField] private float _jumpDuration;
        [SerializeField] private float _jumpDelay;
        [SerializeField] private Ease _jumpEase = Ease.Linear;
        [SerializeField] private Transform _pointTransform;
        
        public async UniTask Execute(Entity entity, CancellationToken cancellationToken)
        {
            try
            {
                await entity
                    .Transform
                    .DOJump(_pointTransform.position, _jumpPower, 1, _jumpDuration)
                    .SetDelay(_jumpDelay)
                    .SetEase(_jumpEase)
                    .ToUniTask(cancellationToken);
            }
            catch (OperationCanceledException e) { return; }
        }
    }
}