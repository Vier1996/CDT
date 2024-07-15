using ACS.Core.ServicesContainer;
using ACS.Data.DataService.Service;
using ACS.SignalBus.SignalBus;
using InternalAssets.Codebase.Gameplay.Workplaces;

namespace InternalAssets.Codebase.Gameplay.Services
{
    public class WorkplaceService
    {
        private WorkplacesContainer _container;
        private IDataService _dataService;

        public WorkplaceService()
        {
            ServiceContainer.Core
                .Get(out _dataService)
                .Get(out ISignalBusService signalBusService);

            _container = new WorkplacesContainer(signalBusService);
        }

        public Workplace GetWorkplace()
        {
            return null;
        }
    }
}