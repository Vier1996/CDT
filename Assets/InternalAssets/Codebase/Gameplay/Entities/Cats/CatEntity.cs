using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatStats;
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
        
        protected override void Start()
        {
            base.Start();
            
            Bootstrap(_entityComponents);
            
            InitializeStats();
            InitializeStates();
        }
        
        private void InitializeStats()
        {
            Components
                .GetAbstractComponent<IEntityStatsCollector>()
                .TryModifyOrCreate(new CatBusyByBrainStat(this, false));
        }
        
        private void InitializeStates()
        {
            Components
                .GetAbstractComponent<IBehaviorMachine>()
                .Notify(new BehaviorStateProperty(CatBehaviorType.default_idle, null));
        }
    }
}