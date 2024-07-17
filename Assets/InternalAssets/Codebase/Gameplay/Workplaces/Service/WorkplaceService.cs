using System;
using ACS.Core.ServicesContainer;
using ACS.Data.DataService.Service;
using ACS.SignalBus.SignalBus;
using InternalAssets.Codebase.Gameplay.Workers;
using InternalAssets.Codebase.Gameplay.Workers.Base;
using InternalAssets.Codebase.Gameplay.Workplaces.Base;
using InternalAssets.Codebase.Gameplay.Workplaces.Data;

namespace InternalAssets.Codebase.Gameplay.Workplaces.Service
{
    public class WorkplaceService
    {
        private readonly WorkplaceDataModel _dataModel;
        private readonly WorkplacesContainer _container;
        private IDataService _dataService;

        public WorkplaceService()
        {
            ServiceContainer.Core
                .Get(out _dataService)
                .Get(out ISignalBusService signalBusService);

            _container = new WorkplacesContainer(signalBusService);
            _dataModel = _dataService.Models.Resolve<WorkplaceDataModel>();
        }

        public bool TryGetMostAvailableWorkplace(IWorker worker, out Workplace workplace)
        {
            workplace = null;
            
            if (_dataModel.TryGetWorkplaceIdByWorker(worker.WorkerId, out string workplaceId) == false)
            {
                if (_container.TryGetAnyAvailableWorkplace(out workplace))
                    return true;
                
                return false;
            }
            
            return _container.TryGetWorkplace(workplaceId, out workplace);
        }

        public void PrepareWorkingData(string workplaceId, string workerId)
        {
            if (_dataModel.TryGetByWorkplace(workplaceId, out WorkplaceWorkingData data) == false)
            {
                data = new WorkplaceWorkingData()
                {
                    WorkerId = workerId
                };

                if (_dataModel.TryInsertWorkingData(workplaceId, data) == false)
                    throw new ArgumentException("Can not insert WorkplaceWorkingData, by duplication data...");
            }

            data.WorkerId = workerId;
        }

        public void ClearWorkingData(string workplaceId)
        {
            _dataModel.RemoveWorkingData(workplaceId);
        }

        public void SetStartTime(string workplaceId, long startTime)
        {
            _dataModel.SetStartTime(workplaceId, startTime);
        }
    }
}