using System;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Library.Behaviors;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
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
            Add(abstractEntity);
            Add(_catAnimator);
            Add(new BehaviorMachine());
            Add(_translateComponent);

            return this;
        }
    }
}