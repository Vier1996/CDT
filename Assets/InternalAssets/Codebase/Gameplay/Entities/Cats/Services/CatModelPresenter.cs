using System;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatStats;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.Interfaces;
using InternalAssets.Codebase.Library.MonoEntity.Stats;
using InternalAssets.Codebase.Library.Reflection;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.Services
{
    public class CatModelPresenter : MonoBehaviour, IDerivedEntityComponent
    {
        [SerializeField] private SkinnedMeshRenderer _mainRenderer;
        [SerializeField] private SkinnedMeshRenderer _leftEyeRenderer;
        [SerializeField] private SkinnedMeshRenderer _rightEyeRenderer;
        
        private IDisposable _visualDisposable;
        private Material _catModelMaterial;

        public void Bootstrap(Entity entity)
        {
            _catModelMaterial = new Material(_mainRenderer.material);

            _mainRenderer.material = _catModelMaterial;
            _leftEyeRenderer.material = _catModelMaterial;
            _rightEyeRenderer.material = _catModelMaterial;

            if (entity.Components.TryGetAbstractComponent(out IEntityStatsCollector statsCollector))
                _visualDisposable = statsCollector.GetOrCreateStat<CatVisualStat>().Subscribe(OnVisualStatChanged);
        }

        public void Dispose() => _visualDisposable?.Dispose();

        private void OnVisualStatChanged(IEntityStat stat)
        {
            if(stat is not CatVisualStat visualStat) return;
            
            _catModelMaterial.SetInt(visualStat.GetId(nameof(visualStat.EqualEyesColor)), visualStat.EqualEyesColor ? 1 : 0);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.LeftEyeColor)), visualStat.LeftEyeColor);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.RightEyeColor)), visualStat.RightEyeColor);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.EyesPupilColor)), visualStat.EyesPupilColor);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.EyesPupilBlinkColor)), visualStat.EyesPupilBlinkColor);
            _catModelMaterial.SetInt(visualStat.GetId(nameof(visualStat.MonoColoredBody)), visualStat.MonoColoredBody ? 1 : 0);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.BodyUpColor)), visualStat.BodyUpColor);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.BodyDownColor)), visualStat.BodyDownColor);
            _catModelMaterial.SetInt(visualStat.GetId(nameof(visualStat.UniqueTailColor)), visualStat.UniqueTailColor ? 1 : 0);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.TailColor)), visualStat.TailColor);
            _catModelMaterial.SetInt(visualStat.GetId(nameof(visualStat.UniquePawsColor)), visualStat.UniquePawsColor ? 1 : 0);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.PawsColor)), visualStat.PawsColor);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.PawPadsColor)), visualStat.PawPadsColor);
            _catModelMaterial.SetInt(visualStat.GetId(nameof(visualStat.MonoColoredEarFront)), visualStat.MonoColoredEarFront ? 1 : 0);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.EarFrontColor)), visualStat.EarFrontColor);
            _catModelMaterial.SetInt(visualStat.GetId(nameof(visualStat.MonoColoredEarBack)), visualStat.MonoColoredEarBack ? 1 : 0);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.EarBackColor)), visualStat.EarBackColor);
            _catModelMaterial.SetInt(visualStat.GetId(nameof(visualStat.TineNose)), visualStat.TineNose ? 1 : 0);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.NoseFrontColor)), visualStat.NoseFrontColor);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.NoseBackColor)), visualStat.NoseBackColor);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.LegClawsColor)), visualStat.LegClawsColor);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.EyesLidColor)), visualStat.EyesLidColor);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.LipsColor)), visualStat.LipsColor);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.MouthColor)), visualStat.MouthColor);
            _catModelMaterial.SetColor(visualStat.GetId(nameof(visualStat.TeethColor)), visualStat.TeethColor);
            
            _mainRenderer.material = _catModelMaterial;
            _leftEyeRenderer.material = _catModelMaterial;
            _rightEyeRenderer.material = _catModelMaterial;
        }
    }
}