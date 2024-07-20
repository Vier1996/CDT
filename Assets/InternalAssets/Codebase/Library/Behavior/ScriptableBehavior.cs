using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Library.Behavior
{
    [CreateAssetMenu(fileName = nameof(ScriptableBehavior), menuName = "App/Configs/Behavior/" + nameof(ScriptableBehavior))]
    public class ScriptableBehavior : SerializedScriptableObject
    {
        [field: SerializeField] public IBehavior Behavior { get; private set; } = default;
    }
}