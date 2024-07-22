using System;
using System.Collections.Generic;
using System.Linq;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior;
using InternalAssets.Codebase.Library.Assets;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.Colors;
using InternalAssets.Codebase.Library.Extension;
using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.Configs
{
    [CreateAssetMenu(fileName = nameof(CatBehaviorsConfig), menuName = "App/Configs/Behaviors/Cat/" + nameof(CatBehaviorsConfig))]
    [LoadablePathAttribute("Entities/Cat")]
    public class CatBehaviorsConfig : LoadableScriptableObject<CatBehaviorsConfig>
    {
        [field: SerializeField] public CatColorConfig ColorPalette { get; private set; } = new();
        
        [ReadOnly] public List<ScriptableBehavior> Behaviors = new();

        [Button]
        private void GetBehaviors()
        {
            Behaviors.Clear();
            
            List<ScriptableBehavior> behaviors = new();
            
            AssetsCollector.TryGetAssets(out behaviors);

            Behaviors = behaviors.Where(bh => bh.Behavior is ICatBehavior).ToList();
        }
    }

    [Serializable]
    public class CatColorConfig
    {
        [field: SerializeField] public SerializedGradientColor EyeColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor EyePupilColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor EyePupilBlinkColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor BodyUpColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor BodyDownColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor TailColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor PawsColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor PawsPadsColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor EarFrontColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor EarBackColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor NoseFrontColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor NoseBackColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor LegClawsColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor EyesLidColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor LipsColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor MouthColorGradient { get; private set; } = new();
        [field: SerializeField] public SerializedGradientColor TeethColorGradient { get; private set; } = new();
    }
}