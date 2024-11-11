using System.Threading;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Library.MonoEntity.Entities;

namespace InternalAssets.Codebase.Gameplay.CompositeOperations
{
    public interface ICompositeOperation
    {
        public virtual void Construct() { }
        
        public UniTask Execute(Entity entity, CancellationToken cancellationToken);
        public virtual void Terminate() { }
    }
}
