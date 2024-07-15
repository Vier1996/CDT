using InternalAssets.Codebase.Gameplay.Cats.BehaviorTypes;
using InternalAssets.Codebase.Gameplay.Cats.BehaviorTypes.Relaxing;
using InternalAssets.Codebase.Gameplay.Relaxes;
using InternalAssets.Codebase.Gameplay.Workers;
using InternalAssets.Codebase.Library.Behaviors;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Cats
{
    public class CatEntity : Entity, IWorker
    {
        [field: SerializeField, BoxGroup("Worker"), PropertyOrder(-1)] public string WorkerId { get; private set; }

        [SerializeField] protected CatComponents EntityComponents;
        
        [SerializeField] protected RelaxPoint relaxPoint;
        
        public void Start()
        {
            Bootstrap(EntityComponents);
            InitializeStates();
        }

        private void InitializeStates()
        {
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
        
    }
}