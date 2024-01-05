﻿using Codebase.Gameplay.Cats.BehaviorTypes;
using Codebase.Gameplay.Workers;
using Codebase.Gameplay.Workplaces;
using Codebase.Library.Behaviors;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Codebase.Gameplay.Cats
{
    public class CatEntity : Worker
    {
        [SerializeField] protected CatComponents EntityComponents;
        [SerializeField] protected Workplace workplace;

        public void Start()
        {
            InitializeEntity(EntityComponents);
            
            InitializeStates();
        }

        private void InitializeStates()
        {
            EntityComponents.TryGetAbstractComponent(out BehaviorMachine behaviorMachine);

            behaviorMachine
                .AppendBehavior(typeof(CatIdleBehavior), new CatIdleBehavior(EntityComponents))
                //.AppendBehavior(typeof(CatWalkBehavior), new CatWalkBehavior(EntityComponents))
                //.AppendBehavior(typeof(CatRunBehavior), new CatRunBehavior(EntityComponents))
                .AppendBehavior(typeof(CatWorkingBehavior), new CatWorkingBehavior(EntityComponents))
                .SwitchBehavior<CatIdleBehavior>();
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