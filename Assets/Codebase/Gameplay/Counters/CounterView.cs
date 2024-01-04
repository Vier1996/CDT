using Codebase.Gameplay.Enums;
using Codebase.Gameplay.GameResources;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Gameplay.Counters
{
    public class CounterView : MonoBehaviour
    {
        public ResourceType ResourceType => _resourceType;
        public Transform IconTransform => _resourceIcon.transform;
        
        [SerializeField] private Image _resourceIcon;
        [SerializeField] private ResourceType _resourceType;
        [SerializeField] private CounterText _counter;
        [SerializeField] private bool _longFormat;

        private ResourcesService _resourcesService;
        
        private void Start()
        {
            //ServiceLocator.For(this).Get(out _resourcesService);
            
            //_counter.SetCustomFormatter(v => _longFormat ? TextExtension.FormatDouble(v) : TextExtension.FormatShort(v));
            
            UpdateCounter(true);

            _resourcesService.ResourceCountChanged += OnResourceChanged;
        }

        private void OnResourceChanged(ResourceType resourceType)
        {
            if (resourceType == _resourceType) 
                UpdateCounter();
        }

        private void UpdateCounter(bool instant = false)
        {
            double value = _resourcesService.GetResourceAmount(_resourceType);
            
            _counter.SetDuration(instant ? 0f : 1f);
            _counter.ChangeTargetValue(value, true);
        }
        
        private void OnDestroy()
        {
            if(_resourcesService != null)
                _resourcesService.ResourceCountChanged -= OnResourceChanged;
        }
    }
}
