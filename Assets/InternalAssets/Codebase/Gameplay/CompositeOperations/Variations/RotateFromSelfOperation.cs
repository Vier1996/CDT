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
    public class RotateFromSelfOperation : ICompositeOperation
    {
        [SerializeField] private bool _isAwait = true;
        [SerializeField] private float _rotateMin;
        [SerializeField] private float _rotateMax;
        [SerializeField] private float _rotateDuration;
        [SerializeField] private Ease _rotateEase;
        
        public async UniTask Execute(Entity entity, CancellationToken cancellationToken)
        {
            entity.Transform.KillTween();
            
            if (_isAwait == false)
            {
                Vector3 selfRotate = entity.Transform.localRotation.eulerAngles;

                entity
                    .Transform
                    .DOLocalRotate(new Vector3(
                        selfRotate.x, 
                        selfRotate.y + UnityEngine.Random.Range(_rotateMin, _rotateMax), 
                        selfRotate.z), _rotateDuration, RotateMode.FastBeyond360)
                    .SetEase(_rotateEase);
                
                return;
            }
            
            try
            {
                Vector3 selfRotate = entity.Transform.localRotation.eulerAngles;

                await entity
                    .Transform
                    .DOLocalRotate(new Vector3(
                        selfRotate.x, 
                        selfRotate.y + UnityEngine.Random.Range(_rotateMin, _rotateMax), 
                        selfRotate.z), _rotateDuration, RotateMode.FastBeyond360)
                    .SetEase(_rotateEase)
                    .ToUniTask(cancellationToken);
            }
            catch (OperationCanceledException e) { return; }
        }
    }
}