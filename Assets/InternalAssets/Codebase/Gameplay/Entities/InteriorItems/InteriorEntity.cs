using System.Linq;
using InternalAssets.Codebase.Library.Async;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace InternalAssets.Codebase.Gameplay.Entities.InteriorItems
{
    public class InteriorEntity : Entity
    {
        [OdinSerialize] private InteriorComponents _entityComponents;

        private ICancellationPair _cancellationPair;
        
        protected override void Start()
        {
            base.Start();
            
            this.GetCancellationPair(out _cancellationPair);
            
            Bootstrap(_entityComponents);
        }

        [Button] private async void Dispatch(Entity entity)
        {
            if (entity == null || _entityComponents.TryGetAbstractComponent(out InteriorConfig config) == false)
                return;

            InteriorInteractionConfig interactionConfig =
                config.InteractionConfigs.FirstOrDefault(ic => ic.InteractionId.Equals("rest"));
            
            if (interactionConfig == default) return;

            foreach (var operation in interactionConfig.CompositeOperations) 
                await operation.Execute(entity, _cancellationPair.Token);
        }
    }
}
