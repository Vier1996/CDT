using ACS.Core.ServicesContainer;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Navigation
{
    public class NavigationPoint : MonoBehaviour
    {
        [field: SerializeField] public string PointId { get; private set; } = string.Empty;
        [field: SerializeField] public Transform SelfTransform { get; private set; }

        private INavigationService _navigationService;
        
        private void Awake()
        {
            ServiceContainer.Global.TryGetService(out _navigationService);
            
            (_navigationService as INavigationServiceConstructor)!.BindPoint(this);
        }
        
        private void OnDestroy() => (_navigationService as INavigationServiceConstructor)!.UnbindPoint(this);
    }
}