using System;
using System.Collections.Generic;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatStats;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Systems.Brain.Clusters;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.Stats;
using UniRx;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.Systems.Brain
{
    public class CatsBrainSystem
    {
        private readonly List<ICatBrainCluster> _brainClusters = new()
        {
            new CatRandomEvent()
        };
        
        private readonly Dictionary<CatEntity, IDisposable> _catEntities = new();

        public CatsBrainSystem() { }

        public void AddCat(CatEntity entity)
        {
            IDisposable statDisposable = entity
                .Components
                .GetAbstractComponent<IEntityStatsCollector>()
                .GetOrCreateStat<CatBusyByBrainStat>()
                .Subscribe(OnStatChanged);
                
            _catEntities.TryAdd(entity, statDisposable);
        }
        
        public void RemoveCat(CatEntity entity)
        {
            if (_catEntities.TryGetValue(entity, out IDisposable busyDisposable) == false) return;
           
            busyDisposable.Dispose();
            
            _catEntities.Remove(entity);
        }

        private void OnStatChanged(IEntityStat stat)
        {
            if(stat is not CatBusyByBrainStat busyByBrainStat || busyByBrainStat.IsBusy) return;

            foreach (ICatBrainCluster cluster in _brainClusters)
            {
                if(cluster.IsAccepted(busyByBrainStat.Entity))
                    return;
            }
        }

        #region DEBUG

        public void TriggerCat(CatEntity entity)
        {
            foreach (ICatBrainCluster cluster in _brainClusters)
            {
                if(cluster.IsAccepted(entity))
                    return;
            }
        }

        #endregion
    }
}