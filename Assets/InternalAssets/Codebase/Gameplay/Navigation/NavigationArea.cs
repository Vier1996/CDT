using System;
using ACS.Core.ServicesContainer;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace InternalAssets.Codebase.Gameplay.Navigation
{
    public class NavigationArea : MonoBehaviour, INavigationPointProvider
    {
#if UNITY_EDITOR
        [SerializeField] private Color _areaSizeColor;
#endif
        [SerializeField] private Vector3 _areaSize;

        private Camera _camera;
        private Transform _selfTransform;
        private INavigationService _navigationService;
        
        private void Start()
        {
            ServiceContainer.ForCurrentScene().TryGetService(out _camera);
            ServiceContainer.Global.TryGetService(out _navigationService);
                
            _selfTransform = transform;
            
            (_navigationService as INavigationServiceConstructor)!.BindProvider(this);
        }

        private void OnDestroy()
        {
            (_navigationService as INavigationServiceConstructor)!.UnbindProvider(this);
        }

        public Vector3 GetAvailablePoint()
        {
            if (_selfTransform == null)
                _selfTransform = transform;

            int maxIterationCount = 15;

            while (maxIterationCount >= 0)
            {
                Vector3 possiblePoint = GetRandomPosition();

                if (NavMesh.SamplePosition(possiblePoint, out NavMeshHit hit, 2f, 1))
                    return hit.position;

                maxIterationCount--;
            }

            return default;
        }

        public Vector3 GetAvailablePoint(Vector3 boxSize, float spawnOffset, bool checkVisible)
        {
            if (_selfTransform == null)
                _selfTransform = transform;

            int maxIterationCount = 15;

            while (maxIterationCount >= 0)
            {
                Vector3 possiblePoint = GetRandomPosition();

                if (IsPointClear(possiblePoint, _selfTransform.position, boxSize) && (IsPointOffscreen(possiblePoint, spawnOffset, checkVisible)))
                    return possiblePoint;

                maxIterationCount--;
            }
            
            return Vector3.zero;
        }
        
        private bool IsPointOffscreen(Vector3 point, float spawnOffset,  bool checkVisible)
        {
            if (checkVisible == false)
                return true;
            
            Vector3 screenPoint = _camera.WorldToViewportPoint(point);
            return screenPoint.x < -spawnOffset || screenPoint.x > 1 + spawnOffset ||
                   screenPoint.y < -spawnOffset || screenPoint.y > 1 + spawnOffset ||
                   screenPoint.z < 0;
        }
        
        public bool InBounds(Vector3 position)
        {
            Vector3 halfSize = new Vector3(_areaSize.x / 2, _areaSize.y / 2, _areaSize.z / 2);

            bool inBoundsX = position.x >= -halfSize.x && position.x <= halfSize.x;
            bool inBoundsZ = position.z >= -halfSize.z && position.z <= halfSize.z;

            return inBoundsX && inBoundsZ;
        }
        
        private Vector3 GetRandomPosition()
        {
            Vector3 halfSize = new Vector3(_areaSize.x * 0.5f, 0, _areaSize.z * 0.5f);
            Vector3 localRandomPoint = new Vector3(Random.Range(-halfSize.x, halfSize.x), 0, Random.Range(-halfSize.z, halfSize.z));
            Vector3 outputVector = _selfTransform.TransformPoint(localRandomPoint);
            
            return outputVector;
        }
        
        private bool IsPointClear(Vector3 point, Vector3 centre, Vector3 boxSize)
        {
            Vector3 direction = point - centre;
            
            return Physics.BoxCast(centre, boxSize / 2f, direction, Quaternion.identity, direction.magnitude) == false;
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Application.isPlaying ? new Color(_areaSizeColor.r, _areaSizeColor.g, _areaSizeColor.b, 0.05f) : _areaSizeColor;

            Matrix4x4 defaultGizmosMatrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawCube(Vector3.zero, new Vector3(_areaSize.x, _areaSize.y, _areaSize.z));
            Gizmos.matrix = defaultGizmosMatrix;
        }
#endif
    }
}