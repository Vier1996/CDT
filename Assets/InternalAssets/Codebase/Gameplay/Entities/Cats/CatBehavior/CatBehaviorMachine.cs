using System;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Configs;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.Interfaces;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior
{
    public class CatBehaviorMachine : IDerivedEntityComponent
    {
        public BehaviorMachine Machine { get; private set; }

        public void Bootstrap(Entity entity)
        {
            Machine = new BehaviorMachine();
            CatBehaviorsConfig catBehaviorsConfig = CatBehaviorsConfig.GetInstance();
            
            foreach (ICatBehavior enemyBehavior in catBehaviorsConfig.CatBehaviors)
            {
                Type targetBehaviorType = enemyBehavior.GetType();

                if (Activator.CreateInstance(targetBehaviorType, args: enemyBehavior) is not IBehavior behavior)
                    throw new ArgumentException("Разраб где-то обосрался...");

                Machine.AppendBehavior(targetBehaviorType, behavior, entity.Components);
            }
            
            Machine.SwitchToDefaultBehavior();
        }

        public void Dispose() { }
    }
}