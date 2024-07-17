using System;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Workplaces.Base
{
    [Serializable]
    public class WorkplaceComponents : EntityComponents
    {
        [SerializeField] private WorkplaceTransforms _workplaceTransforms;

        public override EntityComponents Declare(Entity abstractEntity)
        {
            Add(typeof(Entity), abstractEntity);
            Add(_workplaceTransforms);
            
            return this;
        }

        [Serializable]
        public class WorkplaceTransforms
        {
            [field: SerializeField] public Transform ModelTransform { get; protected set; }
            [field: SerializeField] public Transform WorkingTransform { get; protected set; }
        }
    }
}