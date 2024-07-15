using System;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Gameplay.Interactable;
using InternalAssets.Codebase.Gameplay.Workers;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Workplaces
{
    public abstract class Workplace : Entity
    {
        public WorkplaceComponents WorkplaceComponents { get; private set; } = null;
        public ReactiveProperty<float> WorkCompleteProgress { get; private set; } = new ReactiveProperty<float>(0f);
        public ReactiveProperty<WorkplaceWorkResult> WorkplaceWorkResult { get; private set; } = new();
        
        protected IWorker CurrentWorker;
        protected IDisposable ChangingProgressDisposable;

        public override Entity Bootstrap(EntityComponents components = null)
        {
            WorkplaceComponents = components as WorkplaceComponents;
            
            return base.Bootstrap(components);
        }

        public virtual bool IsAvailable() => CurrentWorker == null;

        public Workplace SetCurrentWorker(IWorker worker)
        {
            CurrentWorker = worker;
            return this;
        }
        
        public Workplace RemoveCurrentWorker(IWorker worker)
        {
            CurrentWorker = worker;
            return this;
        }
        
        [Button] public abstract void ExecuteWork();
        
        [Button] public abstract void DispatchWork();
        
        protected abstract void FinishWork();

        private void LoadData()
        {
            
        }
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
