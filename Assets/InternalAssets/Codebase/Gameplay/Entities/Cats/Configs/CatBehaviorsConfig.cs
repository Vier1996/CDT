using System.Collections.Generic;
using System.Linq;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior;
using InternalAssets.Codebase.Library.Assets;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.Extension;
using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.Configs
{
    [CreateAssetMenu(fileName = nameof(CatBehaviorsConfig), menuName = "App/Configs/Behaviors/Cat/" + nameof(CatBehaviorsConfig))]
    [LoadablePathAttribute("Entities/Cat")]
    public class CatBehaviorsConfig : LoadableScriptableObject<CatBehaviorsConfig>
    {
        [ReadOnly] public List<ScriptableBehavior> Behaviors = new();

        [Button]
        private void GetBehaviors()
        {
            Behaviors.Clear();
            
            List<ScriptableBehavior> behaviors = new();
            
            AssetsCollector.TryGetAssets(out behaviors);

            Behaviors = behaviors.Where(bh => bh.Behavior is ICatBehavior).ToList();
        }
    }
}