using System;
using InternalAssets.Codebase.Gameplay.Stats.CatStats;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Stats
{
#if UNITY_EDITOR
    public class StatEditorDebug : MonoBehaviour
    {
        private IDisposable _subscribeStatDisposable;
        
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
        private void TestUnsubscribeOnNameStat() => _subscribeStatDisposable?.Dispose();
    }
#endif
}