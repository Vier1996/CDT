namespace Codebase.Library.Behaviors
{
    public interface IBehaviorSwitcher
    {
        public void SwitchBehavior<TBehavior>(System.Action onComplete = null, bool force = false) where TBehavior : IBehavior;
    }
}