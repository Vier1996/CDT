using System;
using ACS.Core.ServicesContainer;
using InternalAssets.Codebase.Gameplay.Generators.Variations.CatsGenerating;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.Stats;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatStats
{
#if UNITY_EDITOR
    public class StatEditorDebug : MonoBehaviour
    {
        private IDisposable _subscribeStatDisposable;
        private CatGenerator _catGenerator;

        private void Start()
        {
            ServiceContainer.Global.TryGetService(out _catGenerator);
        }

        [Button]
        private void TestSubscribeOnNameStat(Entity entity)
        {
            if (entity.Components.TryGetAbstractComponent(out IEntityStatsCollector statsCollector))
                _subscribeStatDisposable = statsCollector.GetOrCreateStat<CatNameStat>().Subscribe(OnNext);
            
            return;
            
            void OnNext(IEntityStat stat)
            {
                if(stat is CatNameStat nameStat)
                    Debug.Log(nameStat.Name);
            } 
        }

        [Button]
        private void TestModifyNameStat(Entity entity, string catName)
        {
            if (entity.Components.TryGetAbstractComponent(out IEntityStatsCollector statsCollector))
                statsCollector.TryModifyOrCreate(new CatNameStat(catName));
        }
        
        [Button]
        private void ApplyColorStat(Entity entity)
        {
            CatGeneratedData data = _catGenerator.Generate();
            
            if (entity.Components.TryGetAbstractComponent(out IEntityStatsCollector statsCollector))
                statsCollector.TryModifyOrCreate(data.CatVisualStat);
        }

        [Button]
        private void TestUnsubscribeOnNameStat() => _subscribeStatDisposable?.Dispose();
    }
#endif
}