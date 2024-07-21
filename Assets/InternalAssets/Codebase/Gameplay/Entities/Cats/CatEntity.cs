using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior.BehaviorTypes;
using InternalAssets.Codebase.Gameplay.Workers.Variations;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats
{
    public class CatEntity : Entity, ICatWorker
    {
        [field: SerializeField, PropertyOrder(-10)] public string WorkerId { get; private set; }

        [SerializeField] private CatComponents _entityComponents;

        private IBehaviorMachine _behaviorMachine;
        
        protected override void Start()
        {
            base.Start();
            
            Bootstrap(_entityComponents);

            _entityComponents.TryGetAbstractComponent(out _behaviorMachine);
            
            InitializeStates();
        }

        private void InitializeStates()
        {
            _behaviorMachine.Notify(new BehaviorStateProperty(
                behaviorType: typeof(CatIdleBehavior),
                components: null));
        }
    }
}