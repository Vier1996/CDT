using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior
{
    public abstract class CatBehaviorState : ICatBehavior
    {
        [field: SerializeField] public bool IsDefaultBehavior { get; set; }
        
        protected EntityComponents EntityComponents;

        public abstract void Construct(EntityComponents components);

        public abstract void Enter(BehaviorComponents behaviorComponents = null);

        public abstract void Exit();

        public virtual void Dispose() { }
    }
}