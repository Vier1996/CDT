using System;
using InternalAssets.Codebase.Gameplay.Interactable;
using InternalAssets.Codebase.Gameplay.Workers;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Workplaces
{
    public abstract class Workplace : Entity
    {
        public WorkplaceComponents WorkplaceComponents { get; private set; } = null;
        
        protected Worker CurrentWorker;
        protected float WorkCompleteProgress = 0f;

        public override Entity Bootstrap(EntityComponents components = null)
        {
            WorkplaceComponents = components as WorkplaceComponents;
            
            return base.Bootstrap(components);
        }

        public virtual bool IsAvailable() => CurrentWorker == null;

        public Workplace SetCurrentWorker(Worker worker)
        {
            CurrentWorker = worker;
            return this;
        }
        
        public Workplace RemoveCurrentWorker(Worker worker)
        {
            CurrentWorker = worker;
            return this;
        }
        
        public Workplace DoWork(float workDuration)
        {
            return this;
        }
        
        public Workplace ReleaseWorker()
        {
            return this;
        }
        
        protected abstract void ExecuteWork(float workDuration);
    }
    
    [Serializable]
    public class WorkplaceComponents : EntityComponents
    {
        [field: SerializeField, BoxGroup("ID")] public string WorkplaceId { get; protected set; } = string.Empty;
        [field: SerializeField, BoxGroup("Transforms")] public Transform ModelTransform { get; protected set; }
        [field: SerializeField, BoxGroup("Transforms")] public Transform WorkingTransform { get; protected set; }

        public override EntityComponents Declare(Entity abstractEntity)
        {
            Add(typeof(Entity), abstractEntity);
            
            return this;
        }
    }
}
