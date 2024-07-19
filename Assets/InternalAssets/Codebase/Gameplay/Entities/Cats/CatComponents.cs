using System;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats
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
            Add(_translateComponent);
            
            Add(new CatBehaviorMachine());

            return this;
        }
    }
}