using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Gameplay.CompositeOperations;
using InternalAssets.Codebase.Library.Async;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using Sirenix.Serialization;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior.BehaviorTypes
{
    [Serializable]
    public class CatCompositeBehavior : CatBehaviorState
    {
        [field: OdinSerialize] public List<ICompositeOperation> BehaviorOperations { get; private set; }

        private ICancellationPair _cancellationPair;
        
        public CatCompositeBehavior(CatCompositeBehavior other)
        {
            BehaviorId = other.BehaviorId;
            IsDefaultBehavior = other.IsDefaultBehavior;
            BehaviorOperations = other.BehaviorOperations;
        }

        public override void Construct(IBehaviorMachine machine, Entity entity)
        {
            Entity = entity;
            
            BehaviorOperations.ForEach(bo => bo.Construct());
        }

        public override async void Enter(IBehaviorComponents behaviorComponents = null)
        {
            _cancellationPair?.Dispose();
            _cancellationPair = AsyncTools.GetNewCancellationPair();

            try
            {
                foreach (var operation in BehaviorOperations) 
                    await operation.Execute(Entity, _cancellationPair.Token);
            }
            catch (OperationCanceledException e) { return; }
        }

        public override UniTask Exit()
        {      
            _cancellationPair?.Dispose();

            return UniTask.CompletedTask;
        }
    }
}
