using System;
using Newtonsoft.Json;

namespace InternalAssets.Codebase.Gameplay.Workplaces.Data
{
    [Serializable]
    public class WorkplaceWorkingData
    {
        [JsonProperty] public string WorkerId = string.Empty;
        [JsonProperty] public long WorkStartAt = 0;
    }
}