using System;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Library.Behaviors;
using InternalAssets.Codebase.Library.SAD;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Cats
{
    [Serializable]
    public class CatComponents : EntityComponents
    {
        [SerializeField] private CatAnimator _catAnimator;
        [SerializeField] private TranslateComponent _translateComponent;
        
        public override EntityComponents Declare(Entity abstractEntity)
        {
            innerComponents.Add(nameof(Entity), abstractEntity);
            innerComponents.Add(nameof(CatAnimator), _catAnimator);
            innerComponents.Add(nameof(BehaviorMachine), new BehaviorMachine());
            innerComponents.Add(nameof(TranslateComponent), _translateComponent);

            return this;
        }

        public void TryAdd(string componentName, object component) => 
            innerComponents.TryAdd(componentName, component);
    }
}