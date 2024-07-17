namespace InternalAssets.Codebase.Gameplay.Workplaces.Base
{
    public abstract class WorkplaceWorkResult { }

    public class StartedWorkResult : WorkplaceWorkResult { }
    
    public class FinishedWorkResult : WorkplaceWorkResult { }

    public class StoppedWorkResult : WorkplaceWorkResult
    {
        public StoppingReason Reason { get; private set; }

        public StoppedWorkResult(StoppingReason reason)
        {
            Reason = reason;
        }

        public enum StoppingReason
        {
            none = 0,
            dispatching = 1,
        }
    }
}