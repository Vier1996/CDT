using InternalAssets.Codebase.Gameplay.Workers.Variations;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats
{
    public class CatEntity : Entity, ICatWorker
    {
        [field: SerializeField, PropertyOrder(-1)] public string WorkerId { get; private set; }

        [SerializeField] protected CatComponents EntityComponents;
        
        protected override void Start()
        {
            base.Start();

            
            Bootstrap(EntityComponents);
            InitializeStates();
        }

        private void InitializeStates()
        {
        }
    }
}