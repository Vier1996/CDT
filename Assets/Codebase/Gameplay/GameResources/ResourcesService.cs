using System;
using ACS.Core;
using ACS.Data.DataService.Service;
using Codebase.Gameplay.Enums;
using Codebase.Gameplay.Models;

namespace Codebase.Gameplay.GameResources
{
    public class ResourcesService
    {
        public event Action<ResourceType> ResourceCountChanged;

        private readonly IDataService _dataService;
        private readonly ResourceModel _resourceModel;
        
        public ResourcesService()
        {
            _dataService = Core.Instance.DataService;
            _resourceModel = _dataService.Models.Resolve<ResourceModel>();
        }

        public double GetResourceAmount(ResourceType resourceType)
        {
            return _resourceModel.Get(resourceType);
        }

        public bool AppendResourceAmount(ResourceType resourceType, double appendingAmount)
        {
            double finalAmount = GetResourceAmount(resourceType) + appendingAmount;
            
            if (finalAmount < 0) 
                return false;
            
            SetResourceAmount(resourceType, finalAmount);
            
            return true;
        }
        
        private void SetResourceAmount(ResourceType resourceType, double amount)
        {
            _resourceModel.Set(resourceType, amount);
            
            ResourceCountChanged?.Invoke(resourceType);
        }
    }
}
