using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Workplaces
{
    public class CodingWorkplace : Workplace
    {
        [BoxGroup("Components"), SerializeField] private CodingWorkplaceComponents _components;

        protected override void ExecuteWork(float workDuration)
        {
        }
    }
    
    [Serializable]
    public class CodingWorkplaceComponents : WorkplaceComponents
    {
    }
}
