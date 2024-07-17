using ACS.SignalBus.SignalBus.Parent;
using InternalAssets.Codebase.Gameplay.Workplaces.Base;

namespace InternalAssets.Codebase.Gameplay.Workplaces.Service.Signals
{
    [Signal]
    public class OperateWorkplaceViewSignal
    {
        public WorkplaceOperateType OperateType = WorkplaceOperateType.none;
        public Workplace Workplace;
        
        public enum WorkplaceOperateType
        {
            none = 0,
            
            subscribe = 1,
            unscribe = 2,
        }
    }
}