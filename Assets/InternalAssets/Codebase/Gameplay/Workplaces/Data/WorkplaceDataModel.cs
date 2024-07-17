using System.Collections.Generic;
using System.Linq;
using ACS.Data.DataService.Model;
using Newtonsoft.Json;

namespace InternalAssets.Codebase.Gameplay.Workplaces.Data
{
    public class WorkplaceDataModel : ProgressModel
    {
        [JsonProperty] private Dictionary<string, WorkplaceWorkingData> _workingDatas = new();

        public bool TryGetByWorkplace(string id, out WorkplaceWorkingData workplaceSubData)
        {
            return _workingDatas.TryGetValue(id, out workplaceSubData);
        }
        
        public bool TryGetWorkplaceIdByWorker(string workerId, out string id)
        {
            id = string.Empty;
            
            KeyValuePair<string, WorkplaceWorkingData> pair = _workingDatas.FirstOrDefault(wd => wd.Value.WorkerId.Equals(workerId));
            
            if(pair.Equals(default(KeyValuePair<string, WorkplaceWorkingData>)))
                return false;

            id = pair.Key;

            return true;
        }
        
        public bool TryInsertWorkingData(string workplaceId, WorkplaceWorkingData subData)
        {
            return _workingDatas.TryAdd(workplaceId, subData);
        }

        public void RemoveWorkingData(string workplaceId)
        {
            if (_workingDatas.ContainsKey(workplaceId))
                _workingDatas.Remove(workplaceId);
        }
        
        public void SetStartTime(string workplaceId, long startTime)
        {
            _workingDatas[workplaceId].WorkStartAt = startTime;
            
            MarkAsDirty();
        }
    }
}