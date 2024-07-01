using InternalAssets.Codebase.Gameplay.Cats.BehaviorTypes;
using InternalAssets.Codebase.Gameplay.Cats.BehaviorTypes.Relaxing;
using InternalAssets.Codebase.Gameplay.Relaxes;
using InternalAssets.Codebase.Gameplay.Workers;
using InternalAssets.Codebase.Gameplay.Workplaces;
using InternalAssets.Codebase.Library.Behaviors;
using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Cats
{
    public class CatEntity : Worker
    {
        [SerializeField] protected CatComponents EntityComponents;
        [SerializeField] protected Workplace workplace;
        [SerializeField] protected RelaxPoint relaxPoint;

        public void Start()
        {
            InitializeEntity(EntityComponents);
            
            EntityComponents.TryAdd(nameof(CatEntity), this);
            
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

#if UNITY_EDITOR

        [Button]
        private void MoveToWork()
        {
            EntityComponents.TryGetAbstractComponent(out BehaviorMachine behaviorMachine);

            behaviorMachine.SwitchBehavior<CatWorkingBehavior>(new CatWorkingBehaviorComponents()
            {
                Workplace = workplace
            });
        }
#endif
    }
}