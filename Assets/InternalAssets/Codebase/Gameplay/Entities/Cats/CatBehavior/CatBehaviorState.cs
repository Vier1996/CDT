﻿using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior
{
    public abstract class CatBehaviorState : ICatBehavior
    {
        [field: SerializeField] public bool IsDefaultBehavior { get; set; }
        
        protected EntityComponents EntityComponents;

        public abstract void Construct(EntityComponents components);

        protected abstract void Enter(BehaviorComponents behaviorComponents = null);

        protected abstract void Exit();

        public virtual void Dispose() { }
    }
}