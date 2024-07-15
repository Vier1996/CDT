using System;
using Newtonsoft.Json;

namespace InternalAssets.Codebase.Gameplay.Data.Models.Workplace
{
    [Serializable]
    public class WorkplaceSubData
    {
        [JsonIgnore] public string WorkplaceId
        {
            get => _workplaceId;
            set => _workplaceId = value;
        }
        
        [JsonIgnore] public string WorkerId
        {
            get => _workerId;
            set => _workerId = value;
        }

        [JsonIgnore] public float Progress
        {
            get => _progress;
            set => _progress = value;
        }
        
        [JsonProperty] private string _workplaceId = string.Empty;
        [JsonProperty] private string _workerId = string.Empty;
        [JsonProperty] private float _progress = 0f;
    }
}