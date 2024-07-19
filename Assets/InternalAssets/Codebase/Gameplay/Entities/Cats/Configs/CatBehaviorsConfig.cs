using System.Collections.Generic;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior;
using InternalAssets.Codebase.Library.Extension;
using Sirenix.Serialization;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.Configs
{
    [CreateAssetMenu(fileName = nameof(CatBehaviorsConfig), menuName = "App/Configs/Behaviors/Cat/" + nameof(CatBehaviorsConfig))]
    public class CatBehaviorsConfig : LoadableScriptableObject<CatBehaviorsConfig>
    {
        [field: OdinSerialize] public List<ICatBehavior> CatBehaviors = new();
    }
}