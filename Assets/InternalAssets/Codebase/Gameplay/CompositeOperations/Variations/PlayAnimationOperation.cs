using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Gameplay.Entities.Base;
using InternalAssets.Codebase.Library.ExceptionExtension;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.CompositeOperations.Variations
{
    [Serializable]
    public class PlayAnimationOperation : ICompositeOperation
    {
        [SerializeField] private string _animationType;

        private IEntityAnimator _animator;
        
        public async UniTask Execute(Entity entity, CancellationToken cancellationToken)
        {
            if (entity.Components.TryGetAbstractComponent(out _animator) == false)
                throw entity.MissedComponent(_animator.GetType());
            
            try
            {
                await _animator.PlayAnimationAsTask(_animationType, force: true).AttachExternalCancellation(cancellationToken);
            }
            catch (OperationCanceledException e)
            {
                return;
            }
        }

        public void Terminate()
        {
            _animator = null;
        }
    }
}
