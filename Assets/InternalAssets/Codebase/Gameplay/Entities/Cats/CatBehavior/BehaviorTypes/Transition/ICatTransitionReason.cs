using System;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior.BehaviorTypes.Transition
{
    public interface ICatTransitionReason
    {
        public Action CompleteEvent { get; }
    }
}