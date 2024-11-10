using System;
using System.Collections.Generic;
using InternalAssets.Codebase.Gameplay.CompositeOperations;
using Sirenix.Serialization;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.InteriorItems
{
    [Serializable]
    public class InteriorConfig
    {
        [field: SerializeField] public string InteriorId { get; private set; } = string.Empty;
        [field: OdinSerialize] public List<InteriorInteractionConfig> InteractionConfigs { get; private set; } = new();
    }

    [Serializable]
    public class InteriorInteractionConfig
    {
        [field: SerializeField] public string InteractionId { get; private set; } = string.Empty;
        [field: OdinSerialize] public List<ICompositeOperation> CompositeOperations { get; private set; } = new();
    }
}
