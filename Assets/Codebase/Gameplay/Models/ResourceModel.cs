using System.Collections.Generic;
using ACS.Data.DataService.Model;
using Codebase.Gameplay.Enums;
using Newtonsoft.Json;

namespace Codebase.Gameplay.Models
{
    public class ResourceModel : ProgressModel
    {
        [JsonProperty] private Dictionary<ResourceType, double> _resources = new();
        
        public double Get(ResourceType resourceType)
        {
            return _resources.ContainsKey(resourceType) ? _resources[resourceType] : 0;
        }

        public void Set(ResourceType resourceType, double amount)
        {
            if (_resources.ContainsKey(resourceType)==false)
            {
                _resources.Add(resourceType, amount);
            }
            else
            {
                _resources[resourceType] = amount;
            }
            
            MarkAsDirty();
        }
    }
}
