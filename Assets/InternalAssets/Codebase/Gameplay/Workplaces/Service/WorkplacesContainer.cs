using System;
using System.Collections.Generic;
using ACS.SignalBus.SignalBus;
using InternalAssets.Codebase.Gameplay.Services.Signals;
using InternalAssets.Codebase.Gameplay.Workplaces;

namespace InternalAssets.Codebase.Gameplay.Services
{
    public class WorkplacesContainer : IDisposable
    {
        public List<Workplace> Workplaces { get; private set; } = new();
        
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

        private void OperateWorkplaceSignal(OperateWorkplaceViewSignal signal)
        {
            switch (signal.OperateType)
            {
                case OperateWorkplaceViewSignal.WorkplaceOperateType.subscribe: Workplaces.Add(signal.Workplace); break;
                case OperateWorkplaceViewSignal.WorkplaceOperateType.unscribe: Workplaces.Remove(signal.Workplace); break;
            }
        }
    }
}