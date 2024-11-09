using System;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Configs;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.Interfaces;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior
{
    public class CatBehaviorMachine : BehaviorMachine, IDerivedEntityComponent
    {
        public void Bootstrap(Entity entity)
        {
            CatDesignConfig catDesign = CatDesignConfig.GetInstance();
            
            foreach (ScriptableBehavior enemyBehavior in catDesign.BehaviorsConfig.Behaviors)
            {
                Type targetBehaviorType = enemyBehavior.Behavior.GetType();

                if (Activator.CreateInstance(targetBehaviorType, args: enemyBehavior.Behavior) is not IBehavior behavior)
                    throw new ArgumentException("Разраб где-то обосрался...");

                AppendBehavior(behavior, entity.Components);
            }
        }
        
        public override void Dispose() { }
    }
}