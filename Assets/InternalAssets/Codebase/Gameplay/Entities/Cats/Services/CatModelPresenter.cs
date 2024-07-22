using System;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatStats;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.Interfaces;
using InternalAssets.Codebase.Library.MonoEntity.Stats;
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
            
            _catModelMaterial.SetInt("SWT - Eye_R from Eye_L", visualStat.EqualEyesColor ? 1 : 0);
            _catModelMaterial.SetColor("Eyes_L_center", visualStat.LeftEyeColor);
            _catModelMaterial.SetColor("Eyes_R_center", visualStat.RightEyeColor);
            _catModelMaterial.SetColor("Eyes_pupil", visualStat.EyesPupilColor);
            _catModelMaterial.SetColor("Eyes_blick", visualStat.EyesPupilBlinkColor);
            _catModelMaterial.SetInt("SWT - Body_down form Body", visualStat.MonoColoredBody ? 1 : 0);
            _catModelMaterial.SetColor("Body", visualStat.BodyUpColor);
            _catModelMaterial.SetColor("Body_down", visualStat.BodyDownColor);
            _catModelMaterial.SetInt("SWT - Tail from Body_down", visualStat.UniqueTailColor ? 1 : 0);
            _catModelMaterial.SetColor("Tail", visualStat.TailColor);
            _catModelMaterial.SetInt("SWT - Leg from Body_down", visualStat.UniquePawsColor ? 1 : 0);
            _catModelMaterial.SetColor("Legs", visualStat.PawsColor);
            _catModelMaterial.SetColor("Legs_paw", visualStat.PawPadsColor);
            _catModelMaterial.SetInt("SWT - Ears_front form Body_down", visualStat.MonoColoredEarFront ? 1 : 0);
            _catModelMaterial.SetColor("Ears_front", visualStat.EarFrontColor);
            _catModelMaterial.SetInt("SWT - Ears_back from Body", visualStat.MonoColoredEarBack ? 1 : 0);
            _catModelMaterial.SetColor("Ears_back", visualStat.EarBackColor);
            _catModelMaterial.SetInt("SWT - Face_nose_below from Body_down", visualStat.TineNose ? 1 : 0);
            _catModelMaterial.SetColor("Face_nose", visualStat.NoseFrontColor);
            _catModelMaterial.SetColor("Face_nose_below", visualStat.NoseBackColor);
            _catModelMaterial.SetColor("Leg_Claws", visualStat.LegClawsColor);
            _catModelMaterial.SetColor("Eyes_lid", visualStat.EyesLidColor);
            _catModelMaterial.SetColor("Mouth_Lips", visualStat.LipsColor);
            _catModelMaterial.SetColor("Mouth", visualStat.MouthColor);
            _catModelMaterial.SetColor("Mouth_teeth", visualStat.TeethColor);
            
            _mainRenderer.material = _catModelMaterial;
            _leftEyeRenderer.material = _catModelMaterial;
            _rightEyeRenderer.material = _catModelMaterial;

        }
    }
}