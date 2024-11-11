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
    public class ToLocalAreaJumpOperation : ICompositeOperation
    {
        [SerializeField] private float _jumpPower;
        [SerializeField] private float _jumpDuration;
        [SerializeField] private float _jumpDelay;
        [SerializeField] private Ease _jumpEase = Ease.Linear;
        [SerializeField] private LocalNavigationArea _navigationArea;
        
        public async UniTask Execute(Entity entity, CancellationToken cancellationToken)
        {
            try
            {
                Vector3 targetPosition = _navigationArea.GetAvailablePoint();
                Vector3 targetLookingPosition = new Vector3(targetPosition.x, entity.Transform.position.y, targetPosition.z);
                
                 entity
                    .Transform
                    .DOLookAt(targetLookingPosition, _jumpDuration, AxisConstraint.None, Vector3.up)
                    .SetEase(Ease.Linear);
                
                await entity
                    .Transform
                    .DOJump(targetPosition, _jumpPower, 1, _jumpDuration)
                    .SetDelay(_jumpDelay)
                    .SetEase(_jumpEase)
                    .ToUniTask(cancellationToken);
            }
            catch (OperationCanceledException e) { return; }
        }
    }
}