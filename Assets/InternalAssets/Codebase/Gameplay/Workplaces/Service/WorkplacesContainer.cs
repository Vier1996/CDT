using System;
using System.Collections.Generic;
using System.Linq;
using ACS.SignalBus.SignalBus;
using InternalAssets.Codebase.Gameplay.Workplaces.Base;
using InternalAssets.Codebase.Gameplay.Workplaces.Service.Signals;

namespace InternalAssets.Codebase.Gameplay.Workplaces.Service
{
    public class WorkplacesContainer : IDisposable
    {
        private List<Workplace> _workplaces = new();
        
        private readonly ISignalBusService _signalBusService;
        
        public WorkplacesContainer(ISignalBusService signalBusService)
        {
            _signalBusService = signalBusService;
            
            _signalBusService.Subscribe<OperateWorkplaceViewSignal>(OperateWorkplaceSignal);
        }
        
        public void Dispose()
        {
            _signalBusService.Unsubscribe<OperateWorkplaceViewSignal>(OperateWorkplaceSignal);
        }

        public bool TryGetWorkplace(string id, out Workplace workplace)
        {
            workplace = _workplaces.FirstOrDefault(wp => wp.WorkplaceId.Equals(id) && wp.IsAvailable);

            return workplace != default;
        }
        
        public bool TryGetAnyAvailableWorkplace(out Workplace workplace)
        {
            workplace = _workplaces.FirstOrDefault(wp => wp.IsAvailable);

            return workplace != default;
        }
        
        private void OperateWorkplaceSignal(OperateWorkplaceViewSignal signal)
        {
            switch (signal.OperateType)
            {
                case OperateWorkplaceViewSignal.WorkplaceOperateType.subscribe: _workplaces.Add(signal.Workplace); break;
                case OperateWorkplaceViewSignal.WorkplaceOperateType.unscribe: _workplaces.Remove(signal.Workplace); break;
            }
        }
    }
}