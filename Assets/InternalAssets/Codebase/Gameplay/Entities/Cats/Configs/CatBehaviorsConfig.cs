using System.Collections.Generic;
using System.Linq;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior;
using InternalAssets.Codebase.Library.Assets;
using InternalAssets.Codebase.Library.Behavior;
using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.Configs
{
    [CreateAssetMenu(fileName = nameof(CatBehaviorsConfig), menuName = "App/Configs/Entities/Cat/" + nameof(CatBehaviorsConfig))]
    public class CatBehaviorsConfig : SerializedScriptableObject
    {
        [field: SerializeField] public List<ScriptableBehavior> Behaviors { get; private set; }

        [Button]
        private void GetBehaviorsInProject()
        {
            Behaviors.Clear();
            
            AssetsCollector.TryGetAssets(out List<ScriptableBehavior> behaviors);

            Behaviors = behaviors.Where(bh => bh.Behavior is ICatBehavior).ToList();
        }
    }
}