using System;
using ACS.Core.ServicesContainer;
using InternalAssets.Codebase.Gameplay.Cats.BehaviorTypes;
using InternalAssets.Codebase.Gameplay.Cats.BehaviorTypes.Relaxing;
using InternalAssets.Codebase.Gameplay.Relaxes;
using InternalAssets.Codebase.Gameplay.Workers.Variations;
using InternalAssets.Codebase.Gameplay.Workplaces.Base;
using InternalAssets.Codebase.Library.Behaviors;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using WorkplaceService = InternalAssets.Codebase.Gameplay.Workplaces.Service.WorkplaceService;

namespace InternalAssets.Codebase.Gameplay.Cats
{
    public class CatEntity : Entity, ICatWorker
    {
        [field: SerializeField, PropertyOrder(-1)] public string WorkerId { get; private set; }

        [SerializeField] protected CatComponents EntityComponents;
        
        [SerializeField] protected RelaxPoint relaxPoint;

        private WorkplaceService _workplaceService;

        protected override void Start()
        {
            base.Start();

            ServiceContainer.Global.TryGetService(out _workplaceService);
            
            Bootstrap(EntityComponents);
            InitializeStates();
        }

        private void InitializeStates()
        {
            return;
            
            EntityComponents.TryGetAbstractComponent(out BehaviorMachine behaviorMachine);

            behaviorMachine
                .AppendBehavior(typeof(CatIdleBehavior), new CatIdleBehavior(EntityComponents))
                .AppendBehavior(typeof(CatRelaxingBehavior), new CatRelaxingBehavior(EntityComponents))
                .AppendBehavior(typeof(CatWorkingBehavior), new CatWorkingBehavior(EntityComponents))
                .SwitchBehavior<CatIdleBehavior>();
        }

        [Button]
        public void TryChangeRelaxing()
        {
            EntityComponents.TryGetAbstractComponent(out BehaviorMachine behaviorMachine);

            behaviorMachine.SwitchBehavior<CatRelaxingBehavior>(new CatRelaxingBehaviorComponents()
            {
                RelaxPoint = relaxPoint
            }, force: true);
        }
        
        private IDisposable workResultDisposable = null;
        private Workplace workplace = null;

        [Button]
        private bool TestBusyByWork()
        {
            if (_workplaceService.TryGetMostAvailableWorkplace(this, out workplace) == false)
            {
                return false;
            }
            
            workplace
                .BindWorker(this)
                .ExecuteWork();

            workResultDisposable = workplace.WorkplaceWorkResult.Subscribe(WorkResultChanged);

            return true;
        }
        
        private void WorkResultChanged(WorkplaceWorkResult result)
        {
            if (result is not FinishedWorkResult) return;
           
            workResultDisposable?.Dispose();
            workplace.ReleaseWorker();
        }
    }
}