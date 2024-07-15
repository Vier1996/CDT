using System;
using InternalAssets.Codebase.Gameplay.Workplaces.Views;
using InternalAssets.Codebase.Library.Extension;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Workplaces
{
    public class CodingWorkplace : Workplace
    {
        [BoxGroup("Components"), SerializeField] private CodingWorkplaceComponents _components = null;
        
        public override Entity Bootstrap(EntityComponents components = null)
        {
            base.Bootstrap(_components);
            
            _components.ProgressView.Hide(0);

            return this;
        }
        
        public override void ExecuteWork()
        {
            ChangingProgressDisposable?.Dispose();
            
            ChangingProgressDisposable = RX
                .DoValue(0f, 1f, 3f, FinishWork)
                .Subscribe(value =>
                {
                    WorkCompleteProgress.Value = value;
                });

            _components.ProgressView
                .Subscribe(this)
                .Display();
        }
        
        public override void DispatchWork()
        {
            ChangingProgressDisposable?.Dispose();
            
            _components.ProgressView
                .Unsubscribe()
                .Hide();
            
            WorkplaceWorkResult.Value = new StoppedWorkResult(StoppedWorkResult.StoppingReason.dispatching);
        }

        protected override void FinishWork()
        {
            ChangingProgressDisposable?.Dispose();
            
            _components.ProgressView
                .Unsubscribe()
                .Hide();
            
            WorkplaceWorkResult.Value = new FinishedWorkResult();
        }
    }
    
    [Serializable]
    public class CodingWorkplaceComponents : WorkplaceComponents
    {
        [field: SerializeField, BoxGroup("ProgressView")] public WorkplaceProgressView ProgressView { get; protected set; }
    }
}
