namespace InternalAssets.Codebase.Library.Behaviors
{
    public interface IBehavior
    {
        public void Enter(BehaviorComponents behaviorComponents = null);
        
        public void Exit();
    }
}