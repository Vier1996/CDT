using System;
using Codebase.Gameplay.Navigation;
using Codebase.Library.Behaviors;
using Codebase.Library.SAD;
using UnityEngine;

namespace Codebase.Gameplay.Cats
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
    }
}