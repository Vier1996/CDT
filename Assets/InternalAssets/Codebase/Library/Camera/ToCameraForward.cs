using System;
using ACS.Core.ServicesContainer;
using UniRx;
using UnityEngine;

namespace InternalAssets.Codebase.Library.Camera
{
    public class ToCameraForward : MonoBehaviour
    {
        private Transform _selfTransform;
        private Transform _mainCameraTransform;
        private IDisposable _workingDisposable;

        private void Awake()
        {
            ServiceContainer.ForCurrentScene().Get(out UnityEngine.Camera camera);
            
            _selfTransform = transform;
            _mainCameraTransform = camera.transform;
            
            _workingDisposable = Observable.EveryFixedUpdate().Subscribe(_ => ToCamera());
        }

        private void OnDestroy() => _workingDisposable?.Dispose();

        private void ToCamera() => _selfTransform.forward = _mainCameraTransform.forward;
    }
}
