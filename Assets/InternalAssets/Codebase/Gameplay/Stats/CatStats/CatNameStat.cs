using System;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Stats.CatStats
{
    [Serializable]
    public class CatNameStat : IEntityStat
    {
        [field: SerializeField] public string Name { get; private set; }

        public CatNameStat(string name)
        {
            Name = name;
        }
    }
}