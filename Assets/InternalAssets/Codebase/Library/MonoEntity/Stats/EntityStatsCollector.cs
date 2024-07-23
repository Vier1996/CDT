using System;
using System.Collections.Generic;
using UniRx;

namespace InternalAssets.Codebase.Library.MonoEntity.Stats
{
    public class EntityStatsCollector : IEntityStatsCollector
    {
        private readonly Dictionary<Type, ReactiveProperty<IEntityStat>> _entityStats = new();
        
        public EntityStatsCollector(List<IEntityStat> stats)
        {
            foreach (IEntityStat stat in stats) 
                TryModifyOrCreate(stat, true);
        }

        public ReactiveProperty<IEntityStat> GetOrCreateStat<T>() where T : IEntityStat
        {
            Type statType = typeof(T);
            
            if (_entityStats.TryGetValue(statType, out var create)) return create;

            Add(Activator.CreateInstance(statType) as IEntityStat);

            return _entityStats[statType];
        }

        public bool TryModifyOrCreate(IEntityStat stat, bool addIfNotPresent = true)
        {
            Type statType = stat.GetType();

            if (_entityStats.ContainsKey(statType) == false)
            {
                if (!addIfNotPresent) return false;
                
                Add(stat);
                
                return true;
            }

            _entityStats[statType].Value = stat;
            
            return true;
        }
        
        private void Add(IEntityStat stat)
        {
            Type statType = stat.GetType();

            if (_entityStats.ContainsKey(statType)) return;
            
            _entityStats.Add(statType, new ReactiveProperty<IEntityStat>(stat));
        }
    }
}