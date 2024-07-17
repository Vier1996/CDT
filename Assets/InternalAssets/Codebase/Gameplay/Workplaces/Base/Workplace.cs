using System;
using ACS.Core.ServicesContainer;
using ACS.SignalBus.SignalBus;
using InternalAssets.Codebase.Gameplay.Workers;
using InternalAssets.Codebase.Gameplay.Workers.Base;
using InternalAssets.Codebase.Gameplay.Workplaces.Configs;
using InternalAssets.Codebase.Gameplay.Workplaces.Data;
using InternalAssets.Codebase.Gameplay.Workplaces.Service;
using InternalAssets.Codebase.Gameplay.Workplaces.Service.Signals;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using Sirenix.OdinInspector;
using UniRx;

namespace InternalAssets.Codebase.Gameplay.Workplaces.Base
{
    public abstract class Workplace : Entity, IWorkplace
    {
        protected const float DefaultStartProgressValue = 0f;
        protected const float DefaultFinishProgressValue = 1f;
        
        public string WorkplaceId => Config.WorkplaceId;
        public bool IsAvailable => _currentWorker == null;
        public IReadOnlyReactiveProperty<WorkplaceWorkResult> WorkplaceWorkResult => _workplaceWorkResult;
        public IReadOnlyReactiveProperty<float> WorkProgress => _workProgress;
        
        protected WorkplaceConfig Config;

        private IWorker _currentWorker;
        private ISignalBusService _signalBusService;

        private WorkplaceService _workplaceService;
        private WorkplaceWorkingData _workplaceWorkingData; 

        private readonly ReactiveProperty<WorkplaceWorkResult> _workplaceWorkResult = new(null);
        private readonly ReactiveProperty<float> _workProgress = new(0f);
        
        public override Entity Bootstrap(EntityComponents components = null)
        {
            base.Bootstrap(components);

            ServiceContainer.Core.Get(out _signalBusService);
            ServiceContainer.Global.Get(out _workplaceService);

            Components.TryGetAbstractComponent(out Config);
            
            _signalBusService.Fire(new OperateWorkplaceViewSignal()
            {
                Workplace = this,
                OperateType = OperateWorkplaceViewSignal.WorkplaceOperateType.subscribe
            });

            TryResumeLoadedData();

            return this;
        }
        
        public IWorkplace BindWorker(IWorker worker)
        {
            _currentWorker = worker;
            return this;
        }

        public IWorkplace ReleaseWorker()
        {
            _currentWorker = null;
            return this;
        }

        [Button] public virtual void ExecuteWork()
        {
            _workplaceService.PrepareWorkingData(WorkplaceId, _currentWorker.WorkerId);
            _workplaceService.SetStartTime(WorkplaceId, DateTime.UtcNow.Ticks);

            _workplaceWorkResult.Value = new StartedWorkResult();
        }

        [Button] public virtual void DispatchWork()
        {
            _workplaceService.ClearWorkingData(WorkplaceId);
            
            _workplaceWorkResult.Value = new StoppedWorkResult(StoppedWorkResult.StoppingReason.dispatching);
        }

        protected void SetWorkProgress(float progress)
        {
            if (progress is < 0 or > 1f)
                throw new ArgumentException($"Invalid progress value: [{progress}]");

            _workProgress.Value = progress;
        }

        protected virtual void FinishWork()
        {
            _workplaceService.ClearWorkingData(WorkplaceId);

            _workplaceWorkResult.Value = new FinishedWorkResult();
        }

        private void TryResumeLoadedData()
        {
            // реализовать подтягивание данных с бд для возобновления или завершения работы
        }
    }
}
