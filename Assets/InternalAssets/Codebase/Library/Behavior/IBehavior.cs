using System;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;

namespace InternalAssets.Codebase.Library.Behavior
{
    public interface IBehavior : IDisposable
    {
        public bool IsDefaultBehavior { get; set; }

        public void Construct(IBehaviorMachine machine, EntityComponents components);
        
        public void Enter(IBehaviorComponents behaviorComponents = null);

        public UniTask Exit();
    }
}