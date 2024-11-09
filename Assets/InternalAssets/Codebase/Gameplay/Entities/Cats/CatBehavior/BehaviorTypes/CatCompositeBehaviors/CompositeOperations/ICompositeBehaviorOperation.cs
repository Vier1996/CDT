using System.Threading;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats
{
    public interface ICompositeBehaviorOperation
    {
        public void Construct(EntityComponents components);
        public void Deconstruct();

        public UniTask Execute(CancellationToken cancellationToken);
    }
}