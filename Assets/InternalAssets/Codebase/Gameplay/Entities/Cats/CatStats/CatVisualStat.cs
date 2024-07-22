using System;
using InternalAssets.Codebase.Library.MonoEntity.Stats;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatStats
{
    [Serializable]
    public class CatVisualStat : IEntityStat
    {
        [field: SerializeField] public bool EqualEyesColor = true;
        [field: SerializeField] public Color LeftEyeColor = Color.white;
        [field: SerializeField] public Color RightEyeColor = Color.white;
        [field: SerializeField] public Color EyesPupilColor = Color.white;
        [field: SerializeField] public Color EyesPupilBlinkColor = Color.white;
        [field: SerializeField] public bool MonoColoredBody = true;
        [field: SerializeField] public Color BodyUpColor = Color.white;
        [field: SerializeField] public Color BodyDownColor = Color.white;
        [field: SerializeField] public bool UniqueTailColor = false;
        [field: SerializeField] public Color TailColor = Color.white;
        [field: SerializeField] public bool UniquePawsColor = false;
        [field: SerializeField] public Color PawsColor = Color.white;
        [field: SerializeField] public Color PawPadsColor = Color.white;
        [field: SerializeField] public bool MonoColoredEarFront = true;
        [field: SerializeField] public Color EarFrontColor = Color.white;
        [field: SerializeField] public bool MonoColoredEarBack = true;
        [field: SerializeField] public Color EarBackColor = Color.white;
        [field: SerializeField] public bool TineNose = true;
        [field: SerializeField] public Color NoseFrontColor = Color.white;
        [field: SerializeField] public Color NoseBackColor = Color.white;
        [field: SerializeField] public Color LegClawsColor = Color.white;
        [field: SerializeField] public Color EyesLidColor = Color.white;
        [field: SerializeField] public Color LipsColor = Color.white;
        [field: SerializeField] public Color MouthColor = Color.white;
        [field: SerializeField] public Color TeethColor = Color.white;
    }

    public class CatVisualStatAttribute : Attribute
    {
        [field: SerializeField] public string PropertyValue { get; private set; }

        public CatVisualStatAttribute(string propertyValue) => 
            PropertyValue = propertyValue;
    }
}