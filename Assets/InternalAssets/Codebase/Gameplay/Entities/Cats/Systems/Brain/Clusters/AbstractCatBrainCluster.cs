using InternalAssets.Codebase.Gameplay.Entities.Cats.CatStats;
using InternalAssets.Codebase.Library.MonoEntity.Stats;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.Systems.Brain.Clusters
{
    public abstract class AbstractCatBrainCluster : ICatBrainCluster
    {
        public abstract bool IsAccepted(CatEntity catEntity);

        protected void SetBusyStat(CatEntity catEntity) => SetBusyStat(catEntity, true);

        protected void ReleaseBusyStat(CatEntity catEntity) => SetBusyStat(catEntity, false);

        private void SetBusyStat(CatEntity catEntity, bool state) =>
            catEntity
                .Components
                .GetAbstractComponent<IEntityStatsCollector>()
                .TryModifyOrCreate(new CatBusyByBrainStat(catEntity, state));
    }
}