using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Gameplay.Navigation;
using InternalAssets.Codebase.Library.ExceptionExtension;
using InternalAssets.Codebase.Library.MonoEntity.Entities;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.CompositeOperations.Variations
{
    [Serializable]
    public class ChangeAgentStateOperation : ICompositeOperation
    {
        [SerializeField] private bool Activate = false;
        
        private TranslateComponent _translateComponent;
        
        public UniTask Execute(Entity entity, CancellationToken cancellationToken)
        {
            if (entity.Components.TryGetAbstractComponent(out _translateComponent) == false)
                throw entity.MissedComponent(_translateComponent.GetType());

            _translateComponent.Agent.enabled = Activate;
            
            return UniTask.CompletedTask;
        }
    }
}