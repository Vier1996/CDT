using System;
using System.Collections.Generic;
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
        
        public string GetId(string propertyName) => CatVisualStatStaticData.GetId(propertyName);

        public CatVisualStat() { }
    }

    public static class CatVisualStatStaticData
    {
        private static readonly Dictionary<string, string> _pair = new()
        {
            { "EqualEyesColor", "Boolean_7CD2C539" },
            { "LeftEyeColor", "Color_BD5AAB2F" },
            { "RightEyeColor", "Color_F909C112" },
            { "EyesPupilColor", "Color_B29D9E15" },
            { "EyesPupilBlinkColor", "Color_D1351635" },
            { "MonoColoredBody", "Boolean_FC9E3EC0" },
            { "BodyUpColor", "Color_229D9C7C" },
            { "BodyDownColor", "Color_13ACA631" },
            { "UniqueTailColor", "Boolean_E0857713" },
            { "TailColor", "Color_92653150" },
            { "UniquePawsColor", "Boolean_523A0F5F" },
            { "PawsColor", "Color_BD909386" },
            { "PawPadsColor", "Color_1EB05C51" },
            { "MonoColoredEarFront", "Boolean_C792849A" },
            { "EarFrontColor", "Color_A38F6A3D" },
            { "MonoColoredEarBack", "Boolean_B1E7E1C2" },
            { "EarBackColor", "Color_BFE7A771" },
            { "TineNose", "Boolean_4C0CF7D3" },
            { "NoseFrontColor", "Color_304ED175" },
            { "NoseBackColor", "Color_C0094F21" },
            { "LegClawsColor", "Color_18ADC7B9" },
            { "EyesLidColor", "Color_32956E0B" },
            { "LipsColor", "Color_2D9384E7" },
            { "MouthColor", "Color_6BAB0765" },
            { "TeethColor", "Color_85313AED" },
        };
        
        public static string GetId(string propertyName) => _pair[propertyName];
    }
}