using ACS.Core.ServicesContainer;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior.BehaviorTypes;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatStats;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Systems.Brain;
using InternalAssets.Codebase.Gameplay.Workers.Variations;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.Stats;
using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats
{
    public class CatEntity : Entity, ICatWorker
    {
        [field: SerializeField, PropertyOrder(-10)] public string WorkerId { get; private set; }
        [SerializeField] private CatComponents _entityComponents;

        private CatsBrainSystem _brainSystem;
        
        protected override void Start()
        {
            base.Start();

            ServiceContainer.Global.TryGetService(out _brainSystem);
            
            Bootstrap(_entityComponents);
            
            InitializeStates();
            InitializeStats();
            
            _brainSystem.AddCat(this);
        }
        
        private void InitializeStates()
        {
            Components
                .GetAbstractComponent<IBehaviorMachine>()
                .Notify(new BehaviorStateProperty(typeof(CatIdleBehavior), null));
        }

        private void InitializeStats()
        {
            Components
                .GetAbstractComponent<IEntityStatsCollector>()
                .TryModifyOrCreate(new CatBusyByBrainStat(this, false));
        }
    }
}