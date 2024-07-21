using System;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Stats.CatStats
{
    [Serializable]
    public class CatVisualStat : IEntityStat
    {
        [field: SerializeField] public bool EqualEyesColor { get; private set; } = true;
        [field: SerializeField] public Color LeftEyeColor { get; private set; } = Color.white;
        [field: SerializeField] public Color RightEyeColor { get; private set; } = Color.white;
        [field: SerializeField] public Color EyesPupilColor { get; private set; } = Color.white;
        [field: SerializeField] public Color EyesPupilBlinkColor { get; private set; } = Color.white;
        [field: SerializeField] public bool MonoColoredBody { get; private set; } = true;
        [field: SerializeField] public Color BodyUpColor { get; private set; } = Color.white;
        [field: SerializeField] public Color BodyDownColor { get; private set; } = Color.white;
        [field: SerializeField] public bool UniqueTailColor { get; private set; } = false;
        [field: SerializeField] public Color TailColor { get; private set; } = Color.white;
        [field: SerializeField] public bool UniquePawsColor { get; private set; } = false;
        [field: SerializeField] public Color PawsColor { get; private set; } = Color.white;
        [field: SerializeField] public Color PawPadsColor { get; private set; } = Color.white;
        [field: SerializeField] public bool MonoColoredEarFront { get; private set; } = true;
        [field: SerializeField] public Color EarFrontColor { get; private set; } = Color.white;
        [field: SerializeField] public bool MonoColoredEarBack { get; private set; } = true;
        [field: SerializeField] public Color EarBackColor { get; private set; } = Color.white;
        [field: SerializeField] public bool TineNose { get; private set; } = true;
        [field: SerializeField] public Color NoseFrontColor { get; private set; } = Color.white;
        [field: SerializeField] public Color NoseBackColor { get; private set; } = Color.white;
        [field: SerializeField] public Color LegClawsColor { get; private set; } = Color.white;
        [field: SerializeField] public Color EyesLidColor { get; private set; } = Color.white;
        [field: SerializeField] public Color LipsColor { get; private set; } = Color.white;
        [field: SerializeField] public Color MouthColor { get; private set; } = Color.white;
        [field: SerializeField] public Color TeethColor { get; private set; } = Color.white;
    }
}