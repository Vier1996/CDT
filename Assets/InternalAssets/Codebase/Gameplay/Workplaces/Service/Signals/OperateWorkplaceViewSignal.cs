using InternalAssets.Codebase.Gameplay.Workplaces;

namespace InternalAssets.Codebase.Gameplay.Services.Signals
{
    public class OperateWorkplaceViewSignal
    {
        public WorkplaceOperateType OperateType { get; private set; } = WorkplaceOperateType.none;
        public Workplace Workplace { get; private set; }
        
        public enum WorkplaceOperateType
        {
            none = 0,
            
            subscribe = 1,
            unscribe = 2,
        }
    }
}