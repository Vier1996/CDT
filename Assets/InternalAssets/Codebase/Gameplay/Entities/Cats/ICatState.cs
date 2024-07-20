using System;
using InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior.BehaviorTypes.Transition;
using Sirenix.Serialization;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats
{
    public interface ICatState { }
    
    [Serializable]
    public class ToIdleState : ICatState { }

    [Serializable]
    public class ToTransitionState : ICatState
    {
        [field: SerializeField] public Transform Target { get; private set; } = default;
        [field: OdinSerialize] public ICatTransitionReason Reason { get; private set; } = default;
    }
}