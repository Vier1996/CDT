using System;
using System.Linq;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using Sirenix.Serialization;

namespace InternalAssets.Codebase.Gameplay.Entities.InteriorItems
{
    [Serializable]
    public class InteriorComponents : EntityComponents
    {
        [OdinSerialize] private InteriorConfig _config;
        
        public override EntityComponents Declare(Entity abstractEntity)
        {
            base.Declare(abstractEntity);
            
            foreach (var operation in _config.InteractionConfigs.SelectMany(config => config.CompositeOperations))
                operation.Construct();
            
            Add(_config);
            
            return this;
        }
    }
}