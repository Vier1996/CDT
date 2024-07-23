using ACS.Core.ServicesContainer;
using InternalAssets.Codebase.Gameplay.Entities.Cats;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior.BehaviorTypes.Transition;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Systems.Brain;
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
        private void TestTransitionBehavior(CatEntity entity, Transform target)
        {
            if (entity.Components.TryGetAbstractComponent(out IBehaviorMachine behaviorMachine))
                behaviorMachine.Notify(new BehaviorStateProperty(typeof(CatTransitionToPointBehavior), new TransitionBehaviorComponents(target.position, null)));
            else
                Debug.Log("Can not get BehaviorMachine with [ICatState]");
        }

        [Button]
        private void TriggerBrain(CatEntity entity)
        {
            ServiceContainer.Global.Get(out CatsBrainSystem system);
            
            system.TriggerCat(entity);
        }
    }
#endif
}