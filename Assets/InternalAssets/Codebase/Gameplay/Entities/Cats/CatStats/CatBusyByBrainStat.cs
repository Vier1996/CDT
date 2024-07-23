using System;
using InternalAssets.Codebase.Library.MonoEntity.Stats;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatStats
{
    [Serializable]
    public class CatBusyByBrainStat : IEntityStat
    {
        [field: SerializeField] public bool IsBusy { get; private set; } = false;
        public CatEntity Entity { get; private set; }

        public CatBusyByBrainStat() { }

        public CatBusyByBrainStat(CatEntity entity, bool isBusy)
        {
            Entity = entity;
            IsBusy = isBusy;
        }
    }
}