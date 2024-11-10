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
    public class PlayNonAwaitableAnimationOperation : ICompositeOperation
    {
        [SerializeField] private string _animationType;

        private IEntityAnimator _animator;

        public UniTask Execute(Entity entity, CancellationToken cancellationToken)
        {
            if (entity.Components.TryGetAbstractComponent(out _animator) == false)
                throw entity.MissedComponent(_animator.GetType());
            
            _animator.PlayAnimation(_animationType, force: true);
            
            return UniTask.CompletedTask;
        }

        public void Terminate()
        {
            _animator = null;
        }
    }
}