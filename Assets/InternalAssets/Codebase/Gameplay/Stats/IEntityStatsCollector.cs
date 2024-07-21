﻿using UniRx;

namespace InternalAssets.Codebase.Gameplay.Stats
{
    public interface IEntityStatsCollector
    {
        public ReactiveProperty<IEntityStat> GetOrCreateStat<T>() where T : IEntityStat;
        public bool TryModifyOrCreate(IEntityStat stat, bool addIfNotPresent = false);
    }
}