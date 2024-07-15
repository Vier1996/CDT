using System.Collections.Generic;
using System.Linq;
using ACS.Data.DataService.Model;
using Newtonsoft.Json;

namespace InternalAssets.Codebase.Gameplay.Data.Models.Workplace
{
    public class WorkplaceDataModel : ProgressModel
    {
        [JsonProperty] private List<WorkplaceSubData> _subDatas = new();

        public WorkplaceSubData GetSubDataByWorkplace(string workplaceId)
        {
            return _subDatas.FirstOrDefault(sd => sd.WorkplaceId.Equals(workplaceId)) ?? null;
        }
        
        public WorkplaceSubData GetSubDataByWorker(string workerId)
        {
            return _subDatas.FirstOrDefault(sd => sd.WorkerId.Equals(workerId)) ?? null;
        }
        
        public bool TryAdd(WorkplaceSubData subData)
        {
            if (_subDatas.Any(sd =>
                    sd.WorkplaceId.Equals(subData.WorkplaceId) &&
                    sd.WorkerId.Equals(subData.WorkerId)))
                return false;
            
            _subDatas.Add(subData);

            return true;
        }
    }
}