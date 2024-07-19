using System;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;

namespace InternalAssets.Codebase.Library.Behavior
{
    public interface IBehavior : IDisposable
    {
        public bool IsDefaultBehavior { get; set; }

        public void Construct(EntityComponents components);

        public void Enter(BehaviorComponents behaviorComponents = null);
        
        public void Exit();
    }
}