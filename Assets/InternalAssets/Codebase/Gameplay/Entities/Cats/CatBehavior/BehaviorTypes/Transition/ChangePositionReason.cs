using System;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior.BehaviorTypes.Transition
{
    public class ChangePositionReason : ICatTransitionReason
    {
        public Action CompleteEvent { get; private set; }

        public ChangePositionReason(Action completeEvent)
        {
            CompleteEvent = completeEvent;
        }
    }
}