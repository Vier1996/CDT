using System;
using System.Threading;
using ACS.Core.ServicesContainer;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Enums;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats
{
    [Serializable]
    public class PlayAnimationOperation : ICompositeBehaviorOperation
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

        public async UniTask Execute(CancellationToken cancellationToken)
        {
            try
            {
                await _catAnimator.PlayAnimationAsTask(_animationType, force: true).AttachExternalCancellation(cancellationToken);
            }
            catch (OperationCanceledException e)
            {
                return;
            }
        }
    }
}