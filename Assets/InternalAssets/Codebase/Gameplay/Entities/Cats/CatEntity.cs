using InternalAssets.Codebase.Gameplay.Workers.Variations;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats
{
    public class CatEntity : Entity, ICatWorker
    {
        [field: SerializeField, PropertyOrder(-10)] public string WorkerId { get; private set; }

        [SerializeField] private CatComponents _entityComponents;
        
        public IReadOnlyReactiveProperty<ICatState> StateChangedProperty => _stateChangedProperty;
        
        private readonly ReactiveProperty<ICatState> _stateChangedProperty = new ();
        
        protected override void Start()
        {
            base.Start();
            
            Bootstrap(_entityComponents);
            
            InitializeStates();
        }

        private void InitializeStates() => _stateChangedProperty.Value = new ToIdleState();

#if UNITY_EDITOR
        [Button]
        private void DebugTransit(ToTransitionState state)
        {
            _stateChangedProperty.Value = state;
        }
#endif
    }
}