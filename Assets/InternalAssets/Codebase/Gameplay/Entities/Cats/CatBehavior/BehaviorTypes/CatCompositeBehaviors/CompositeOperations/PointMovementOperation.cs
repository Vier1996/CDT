using System;
using System.Threading;
using ACS.Core.ServicesContainer;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats
{
    [Serializable]
    public class PointMovementOperation : ICompositeBehaviorOperation
    {
        [SerializeField] private string _pointId = string.Empty;
        
        private INavigationService _navigationService;
        private TranslateComponent _translateComponent;

        public void Construct(EntityComponents components)
        {
            ServiceContainer.Global.TryGetService(out _navigationService);
            components.TryGetAbstractComponent(out _translateComponent);
        }

        public void Deconstruct()
        {
        }

        public async UniTask Execute(CancellationToken cancellationToken)
        {
            if (_navigationService.TryGetPointById(_pointId, out Vector3 point) == false)
                return;

            try
            {
                await _translateComponent
                    .Translate(targetPosition: point)
                    .AttachExternalCancellation(cancellationToken);
            }
            catch (OperationCanceledException e)
            {
                return;
            }
        }
    }
}