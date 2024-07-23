using System;
using InternalAssets.Codebase.Library.MonoEntity.Stats;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatStats
{
    [Serializable]
    public class CatNameStat : IEntityStat
    {
        [field: SerializeField] public string Name { get; private set; }

        public CatNameStat() { }

        public CatNameStat(string name)
        {
            Name = name;
        }
    }
}