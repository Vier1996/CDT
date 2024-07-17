using System;
using InternalAssets.Codebase.Gameplay.Workplaces.Base;
using InternalAssets.Codebase.Gameplay.Workplaces.Configs;
using InternalAssets.Codebase.Gameplay.Workplaces.Views;
using InternalAssets.Codebase.Library.Extension;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Workplaces.WorkplaceVariations
{
    public class CodingWorkplace : Workplace
    {
        [BoxGroup("Components"), SerializeField] private CodingWorkplaceComponents _components = null;
 
        private WorkplaceProgressView _progressView;
        private IDisposable _workDisposable;
        
        public override Entity Bootstrap(EntityComponents components = null)
        {
            base.Bootstrap(_components);

            Components.TryGetAbstractComponent(out _progressView);
            
            _progressView.Hide(0);

            return this;
        }
        
        public override void ExecuteWork()
        {
            _workDisposable?.Dispose();
            _workDisposable = RX.DoValue(
                    from: DefaultStartProgressValue, 
                    to: DefaultFinishProgressValue, 
                    duration: Config.WorkingSeconds, 
                    onComplete: FinishWork).Subscribe(SetWorkProgress);

            _progressView
                .Subscribe(this)
                .Display();
            
            base.ExecuteWork();
        }
        
        public override void DispatchWork()
        {
            _workDisposable?.Dispose();
            
            _progressView
                .Unsubscribe()
                .Hide();
            
            base.DispatchWork();
        }

        protected override void FinishWork()
        {
            _workDisposable?.Dispose();
            
            _progressView
                .Unsubscribe()
                .Hide();
            
            base.FinishWork();
        }
    }
    
    [Serializable]
    public class CodingWorkplaceComponents : WorkplaceComponents
    {
        [SerializeField] private WorkplaceConfig _workplaceConfig;
        [SerializeField] private WorkplaceProgressView _progressView;
        
        public override EntityComponents Declare(Entity abstractEntity)
        {
            base.Declare(abstractEntity);
            
            Add(_workplaceConfig);
            Add(_progressView);
            
            return this;
        }
    }
}
