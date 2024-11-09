using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior;
using InternalAssets.Codebase.Library.Async;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using Sirenix.Serialization;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats
{
    [Serializable]
    public class CatCompositeBehavior : CatBehaviorState
    {
        [field: OdinSerialize] public List<ICompositeBehaviorOperation> BehaviorOperations { get; private set; }

        private ICancellationPair _cancellationPair;
        
        public CatCompositeBehavior(CatCompositeBehavior other)
        {
            BehaviorId = other.BehaviorId;
            IsDefaultBehavior = other.IsDefaultBehavior;
            BehaviorOperations = other.BehaviorOperations;
        }

        public override void Construct(IBehaviorMachine machine, EntityComponents components)
        {
            EntityComponents = components;
            
            BehaviorOperations.ForEach(bo => bo.Construct(EntityComponents));
        }

        public override async void Enter(IBehaviorComponents behaviorComponents = null)
        {
            _cancellationPair?.Dispose();
            _cancellationPair = AsyncTools.GetNewCancellationPair();

            try
            {
                foreach (var operation in BehaviorOperations) 
                    await operation.Execute(_cancellationPair.Token);
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
