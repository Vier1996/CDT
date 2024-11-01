﻿using System;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Services;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;
using InternalAssets.Codebase.Library.MonoEntity.Stats;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats
{
    [Serializable]
    public class CatComponents : EntityComponents
    {
        [SerializeField] private CatAnimator _catAnimator;
        [SerializeField] private TranslateComponent _translateComponent;
        [SerializeField] private EntityStatsCollectorMono _statsCollectorMono;
        [SerializeField] private CatModelPresenter _catModelPresenter;
        
        public override EntityComponents Declare(Entity abstractEntity)
        {
            Add(abstractEntity);
            
            Add(typeof(IEntityStatsCollector), _statsCollectorMono.Bootstrap());
            Add(_catAnimator);
            Add(_translateComponent);
            Add(_catModelPresenter);
            
            Add(typeof(IBehaviorMachine), new CatBehaviorMachine());

            return this;
        }
    }
}