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
        private readonly CatBehaviorsConfig _config;

        public CatGenerator() => _config = CatBehaviorsConfig.GetInstance();

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
            
            Color eyesColor = _config.ColorPalette.EyeColorGradient.GetColor();
            Color bodyUpColor = _config.ColorPalette.BodyUpColorGradient.GetColor();
            Color tailColor = _config.ColorPalette.TailColorGradient.GetColor();
            Color pawsColor = _config.ColorPalette.PawsColorGradient.GetColor();
            Color earFrontColor = _config.ColorPalette.EarFrontColorGradient.GetColor();
            Color earBackColor = _config.ColorPalette.EarBackColorGradient.GetColor();
                
            return new CatVisualStat()
            {
                EqualEyesColor = isEqualEyesColor,
                LeftEyeColor = eyesColor,
                RightEyeColor = isEqualEyesColor ? eyesColor : _config.ColorPalette.EyeColorGradient.GetColor(),
                EyesPupilColor = _config.ColorPalette.EyePupilColorGradient.GetColor(),
                EyesPupilBlinkColor = _config.ColorPalette.EyePupilBlinkColorGradient.GetColor(),
                MonoColoredBody = monoColoredBody,
                BodyUpColor = bodyUpColor,
                BodyDownColor = monoColoredBody ? bodyUpColor : _config.ColorPalette.BodyDownColorGradient.GetColor(),
                UniqueTailColor = uniqueTailColor,
                TailColor = tailColor,
                UniquePawsColor = uniquePadsColor,
                PawsColor = pawsColor,
                PawPadsColor = _config.ColorPalette.PawsPadsColorGradient.GetColor(),
                MonoColoredEarFront = monoColoredFront,
                EarFrontColor = earFrontColor,
                MonoColoredEarBack = monoColoredBack,
                EarBackColor = earBackColor,
                TineNose = WeightRandom.DoChance(50f),
                NoseFrontColor = _config.ColorPalette.NoseFrontColorGradient.GetColor(),
                NoseBackColor = _config.ColorPalette.NoseBackColorGradient.GetColor(),
                LegClawsColor = _config.ColorPalette.LegClawsColorGradient.GetColor(),
                EyesLidColor = _config.ColorPalette.EyesLidColorGradient.GetColor(),
                LipsColor = _config.ColorPalette.LipsColorGradient.GetColor(),
                MouthColor = _config.ColorPalette.MouthColorGradient.GetColor(),
                TeethColor = _config.ColorPalette.TeethColorGradient.GetColor(),
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