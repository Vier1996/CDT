using InternalAssets.Codebase.Library.Extension;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.Configs
{
    [CreateAssetMenu(fileName = nameof(CatDesignConfig), menuName = "App/Configs/Entities/Cat/" + nameof(CatDesignConfig))]
    [LoadablePathAttribute("Entities/Cat")]
    public class CatDesignConfig : LoadableScriptableObject<CatDesignConfig>
    {
        [field: SerializeField] public CatBehaviorsConfig BehaviorsConfig { get; private set; }
        [field: SerializeField] public CatColorConfig ColorConfig { get; private set; }
    }
}
