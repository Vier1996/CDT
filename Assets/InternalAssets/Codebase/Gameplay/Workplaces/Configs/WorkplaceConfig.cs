using InternalAssets.Codebase.Library.Extension;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Workplaces.Configs
{
    [CreateAssetMenu(fileName = nameof(WorkplaceConfig), menuName = "App/Configs/Workplace/" + nameof(WorkplaceConfig))]
    public class WorkplaceConfig : LoadableScriptableObject<WorkplaceConfig>
    {
        [field: SerializeField] public float WorkingSeconds { get; private set; } = 0;
    }
}