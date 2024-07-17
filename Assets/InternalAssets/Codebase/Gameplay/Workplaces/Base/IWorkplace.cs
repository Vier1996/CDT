using InternalAssets.Codebase.Gameplay.Workers;
using InternalAssets.Codebase.Gameplay.Workers.Base;
using UniRx;

namespace InternalAssets.Codebase.Gameplay.Workplaces.Base
{
    public interface IWorkplace
    {
        public string WorkplaceId { get; }
        public bool IsAvailable { get; }
        
        public IReadOnlyReactiveProperty<WorkplaceWorkResult> WorkplaceWorkResult { get; }
        public IReadOnlyReactiveProperty<float> WorkProgress  { get; }

        public IWorkplace BindWorker(IWorker worker);
        public IWorkplace ReleaseWorker();

        public void ExecuteWork();
        public void DispatchWork();
    }
}