using System;

namespace InternalAssets.Codebase.Library.MonoEntity.Stats.Base
{
    [Serializable]
    public class EntityIdStat : IEntityStat
    {
        public string EntityId { get; private set; }

        public EntityIdStat(string entityId)
        {
            EntityId = entityId;
        }
    }
}