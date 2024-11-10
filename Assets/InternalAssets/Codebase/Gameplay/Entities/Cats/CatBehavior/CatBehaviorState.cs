using System;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior
{
    [Serializable]
    public abstract class CatBehaviorState : ICatBehavior
    {
        [field: SerializeField] public string BehaviorId { get; set; } = string.Empty;
        [field: SerializeField] public bool IsDefaultBehavior { get; set; }
        
        protected Entity Entity;
        
        private IDisposable _subscriptionToStateDisposable;

        public abstract void Construct(IBehaviorMachine machine, Entity entity);
        public virtual void Dispose() { }
        
        public abstract void Enter(IBehaviorComponents behaviorComponents = null);
        public abstract UniTask Exit();
    }
}