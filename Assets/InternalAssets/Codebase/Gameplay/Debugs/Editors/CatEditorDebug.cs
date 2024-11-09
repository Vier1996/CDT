using InternalAssets.Codebase.Gameplay.Entities.Cats;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Debugs.Editors
{
#if UNITY_EDITOR
    public class CatEditorDebug : MonoBehaviour
    {
        [Button]
        private void TestCatBehavior(IEntity entity, BehaviorStateProperty property)
        {
            if (entity.Components.TryGetAbstractComponent(out IBehaviorMachine behaviorMachine))
                behaviorMachine.Notify(property);
            else
                Debug.Log("Can not get BehaviorMachine with [ICatState]");
        }

        [Button]
        private void TestCompositeBehavior(CatEntity entity, string catBehaviorType)
        {
            if (entity.Components.TryGetAbstractComponent(out IBehaviorMachine behaviorMachine))
                behaviorMachine.Notify(new(catBehaviorType, default));
        }
    }
#endif
}