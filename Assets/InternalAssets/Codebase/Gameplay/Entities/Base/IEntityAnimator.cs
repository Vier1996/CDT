using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;

namespace InternalAssets.Codebase.Gameplay.Entities.Base
{
    public interface IEntityAnimator
    {
        [Button] public UniTask PlayAnimationAsTask(string animationType, bool force = false);

        [Button] public void PlayAnimation(string animationType, bool force = false);

        [Button] public void StopAnimator();
    }
}
