using ACS.Core.ServicesContainer;
using UnityEngine;
using UnityEngine.AI;

namespace InternalAssets.Codebase.Gameplay.Navigation
{
    public class LocalNavigationArea : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private Color _areaSizeColor;
#endif
        [SerializeField] private Vector3 _areaSize;

        private Transform _selfTransform;
        private INavigationService _navigationService;
        
        private void Start()
        {
            ServiceContainer.Global.TryGetService(out _navigationService);
                
            _selfTransform = transform;
        }

        public Vector3 GetAvailablePoint()
        {
            if (_selfTransform == null)
                _selfTransform = transform;
            
            return GetRandomPosition();
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