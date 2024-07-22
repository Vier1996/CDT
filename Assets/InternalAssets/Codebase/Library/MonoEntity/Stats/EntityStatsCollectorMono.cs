using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UniRx;

namespace InternalAssets.Codebase.Library.MonoEntity.Stats
{
    public class EntityStatsCollectorMono : SerializedMonoBehaviour, IEntityStatsCollector
    {
        [OdinSerialize] private List<IEntityStat> _entityStats = new();

        private IEntityStatsCollector _entityStatsCollector;

        public EntityStatsCollectorMono Bootstrap()
        {
            _entityStatsCollector = new EntityStatsCollector(_entityStats);
            
            return this;
        }
        
        public void Dispose()
        {
            
        }
        
        public ReactiveProperty<IEntityStat> GetOrCreateStat<T>() where T : IEntityStat => _entityStatsCollector.GetOrCreateStat<T>();

        public bool TryModifyOrCreate(IEntityStat stat, bool addIfNotPresent = false) => _entityStatsCollector.TryModifyOrCreate(stat, addIfNotPresent);
    }
}