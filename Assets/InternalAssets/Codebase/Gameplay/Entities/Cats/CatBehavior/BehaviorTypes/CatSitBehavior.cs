using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Gameplay.Entities.Cats.Enums;
using InternalAssets.Codebase.Library.Behavior;
using InternalAssets.Codebase.Library.MonoEntity.EntityComponent;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.CatBehavior.BehaviorTypes
{
    public class CatSitBehavior : CatBehaviorState
    {
        private CatAnimator _catAnimator;
        
        public CatSitBehavior(CatSitBehavior other) => IsDefaultBehavior = other.IsDefaultBehavior;

        public override void Construct(IBehaviorMachine machine, EntityComponents components)
        {
            EntityComponents = components;
            EntityComponents.TryGetAbstractComponent(out _catAnimator);
        }

        public override async void Enter(IBehaviorComponents behaviorComponents = null)
        {
            await _catAnimator.PlayAnimationAsTask(CatAnimationType.rest_sit_to, force: true);
            _catAnimator.PlayAnimation(CatAnimationType.rest_sit_idle);
        }

        public override async UniTask Exit()
        {
            await _catAnimator.PlayAnimationAsTask(CatAnimationType.rest_sit_from, force: true);
        }
    }
}