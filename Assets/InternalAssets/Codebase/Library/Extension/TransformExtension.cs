using DG.Tweening;
using UnityEngine;

namespace InternalAssets.Codebase.Library.Extension
{
    public static class TransformExtension
    {
        public static void Normalize(this Transform self, Transform to, float normalizeSpeed = 0.1f)
        {
            Vector3 direction = to.position - self.position;
            Quaternion quaternion = Quaternion.Euler(0f, (-Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg) + 90, 0);

            self
                .DORotate(quaternion.eulerAngles, normalizeSpeed)
                .SetEase(Ease.InOutSine);
        }
    }
}