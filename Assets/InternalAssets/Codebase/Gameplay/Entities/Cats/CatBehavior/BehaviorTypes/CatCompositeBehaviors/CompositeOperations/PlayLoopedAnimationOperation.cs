using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Enums;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats
{
    [Serializable]
    public class PlayLoopedAnimationOperation : ICompositeBehaviorOperation
    {
        [SerializeField] private CatAnimationType _animationType;

        private CatAnimator _catAnimator;

        public void Construct(EntityComponents components)
        {
            components.TryGetAbstractComponent(out _catAnimator);
        }

        public void Deconstruct()
        {
            _catAnimator = null;
        }

        public UniTask Execute(CancellationToken cancellationToken)
        {
            _catAnimator.PlayAnimation(_animationType, force: true);
            
            return UniTask.Never(cancellationToken);
        }
    }
    
    [Serializable]
    public class PlayAnimationVoidOperation : ICompositeBehaviorOperation
    {
        [SerializeField] private CatAnimationType _animationType;

        private CatAnimator _catAnimator;

        public void Construct(EntityComponents components)
        {
            components.TryGetAbstractComponent(out _catAnimator);
        }

        public void Deconstruct()
        {
            _catAnimator = null;
        }

        public UniTask Execute(CancellationToken cancellationToken)
        {
            _catAnimator.PlayAnimation(_animationType, force: true);
            
            return UniTask.CompletedTask;
        }
    }
}