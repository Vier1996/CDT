using System;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatStats;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Configs;
using InternalAssets.Codebase.Library.MonoEntity.Stats.Base;
using InternalAssets.Codebase.Library.Random;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Generators.Variations.CatsGenerating
{
    public class CatGenerator : IGenerator<CatGeneratedData>
    {
        private readonly CatColorConfig _colorConfig;

        public CatGenerator()
        {
            _colorConfig = CatDesignConfig.GetInstance().ColorConfig;
        }

        public CatGeneratedData Generate() =>
            new()
            {
                EntityIdStat = new EntityIdStat(Guid.NewGuid().ToString("N")),
                CatNameStat = new CatNameStat($"Template:{UnityEngine.Random.Range(1, 26)}"),
                CatVisualStat = GenerateVisual()
            };

        private CatVisualStat GenerateVisual()
        {
            bool isEqualEyesColor = WeightRandom.DoChance(80f);
            bool monoColoredBody = WeightRandom.DoChance(25f);
            bool uniqueTailColor = WeightRandom.DoChance(60f);
            bool uniquePadsColor = WeightRandom.DoChance(60f);
            bool monoColoredFront = WeightRandom.DoChance(75f);
            bool monoColoredBack = WeightRandom.DoChance(75f);
            
            Color eyesColor = _colorConfig.EyeColorGradient.GetColor();
            Color bodyUpColor = _colorConfig.BodyUpColorGradient.GetColor();
            Color tailColor = _colorConfig.TailColorGradient.GetColor();
            Color pawsColor = _colorConfig.PawsColorGradient.GetColor();
            Color earFrontColor = _colorConfig.EarFrontColorGradient.GetColor();
            Color earBackColor = _colorConfig.EarBackColorGradient.GetColor();
                
            return new CatVisualStat()
            {
                EqualEyesColor = isEqualEyesColor,
                LeftEyeColor = eyesColor,
                RightEyeColor = isEqualEyesColor ? eyesColor : _colorConfig.EyeColorGradient.GetColor(),
                EyesPupilColor = _colorConfig.EyePupilColorGradient.GetColor(),
                EyesPupilBlinkColor = _colorConfig.EyePupilBlinkColorGradient.GetColor(),
                MonoColoredBody = monoColoredBody,
                BodyUpColor = bodyUpColor,
                BodyDownColor = monoColoredBody ? bodyUpColor : _colorConfig.BodyDownColorGradient.GetColor(),
                UniqueTailColor = uniqueTailColor,
                TailColor = tailColor,
                UniquePawsColor = uniquePadsColor,
                PawsColor = pawsColor,
                PawPadsColor = _colorConfig.PawsPadsColorGradient.GetColor(),
                MonoColoredEarFront = monoColoredFront,
                EarFrontColor = earFrontColor,
                MonoColoredEarBack = monoColoredBack,
                EarBackColor = earBackColor,
                TineNose = WeightRandom.DoChance(50f),
                NoseFrontColor = _colorConfig.NoseFrontColorGradient.GetColor(),
                NoseBackColor = _colorConfig.NoseBackColorGradient.GetColor(),
                LegClawsColor = _colorConfig.LegClawsColorGradient.GetColor(),
                EyesLidColor = _colorConfig.EyesLidColorGradient.GetColor(),
                LipsColor = _colorConfig.LipsColorGradient.GetColor(),
                MouthColor = _colorConfig.MouthColorGradient.GetColor(),
                TeethColor = _colorConfig.TeethColorGradient.GetColor(),
            };
        }
    }

    [Serializable]
    public class CatGeneratedData
    {
        public EntityIdStat EntityIdStat = default;
        public CatNameStat CatNameStat = default;
        public CatVisualStat CatVisualStat = default;
    }
}