using System;
using System.Threading;
using ACS.Core.ServicesContainer;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Library.ExceptionExtension;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.CompositeOperations.Variations
{
    [Serializable]
    public class ToTransformMovementOperation : ICompositeOperation
    {
        [SerializeField] private Transform _pointTransform;
        
        private INavigationService _navigationService;
        private TranslateComponent _translateComponent;

        public void Construct()
        {
            ServiceContainer.Global.TryGetService(out _navigationService);
        }
        
        public async UniTask Execute(Entity entity, CancellationToken cancellationToken)
        {
            if (_navigationService.TryGetPoint(_pointTransform.position, out Vector3 point) == false)
                return;
             
            if (entity.Components.TryGetAbstractComponent(out _translateComponent) == false)
                throw entity.MissedComponent(_translateComponent.GetType());

            try
            {
                await _translateComponent
                    .Translate(targetPosition: point)
                    .AttachExternalCancellation(cancellationToken);
            }
            catch (OperationCanceledException e) { return; }
        }

        public void Terminate()
        {
            _navigationService = null;
            _translateComponent = null;
        }
    }
}