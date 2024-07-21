using System;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior
{
    public abstract class CatBehaviorState : ICatBehavior
    {
        [field: SerializeField] public bool IsDefaultBehavior { get; set; }
        
        protected EntityComponents EntityComponents;
        
        private IDisposable _subscriptionToStateDisposable;

        public abstract void Construct(IBehaviorMachine machine, EntityComponents components);
        public virtual void Dispose() { }
        
        public abstract void Enter(IBehaviorComponents behaviorComponents = null);

        public abstract void Exit();
    }
}