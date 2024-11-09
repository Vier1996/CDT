using System;
using InternalAssets.Codebase.Library.Colors;
using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.Configs
{
    [CreateAssetMenu(fileName = nameof(CatColorConfig), menuName = "App/Configs/Entities/Cat/" + nameof(CatColorConfig))]
    public class CatColorConfig : SerializedScriptableObject
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