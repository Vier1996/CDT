﻿using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
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

        public static async UniTaskVoid DisplayTaptic(this Transform parent, Transform background, float duration = 0.4f)
        {
            parent.KillTween();
            background.KillTween();
            
            parent.DOScale(1f, duration * 0.5f);

            await background.DOScale(new Vector3(1.2f, 0.8f, 1f), duration * 0.25f).AsyncWaitForCompletion();
            await background.DOScale(new Vector3(0.95f, 1.15f, 1f), duration * 0.25f).AsyncWaitForCompletion();
            await background.DOScale(new Vector3(1.025f, 0.95f, 1f), duration * 0.25f).AsyncWaitForCompletion();
            await background.DOScale(Vector3.one, duration * 0.25f).AsyncWaitForCompletion();
        }
        
        public static async UniTaskVoid HideTaptic(this Transform parent, Transform background, float duration = 0.4f)
        {
            parent.KillTween();
            background.KillTween();
            
            parent.DOScale(0f, duration * 0.5f).SetDelay(duration * 0.5f);

            await background.DOScale(new Vector3(1.025f, 0.95f, 1f), duration * 0.25f).AsyncWaitForCompletion();
            await background.DOScale(new Vector3(0.95f, 1.15f, 1f), duration * 0.25f).AsyncWaitForCompletion();
            await background.DOScale(new Vector3(1.2f, 0.8f, 1f), duration * 0.25f).AsyncWaitForCompletion();
            await background.DOScale(Vector3.one, duration * 0.25f).AsyncWaitForCompletion();
        }
        
        public static TweenerCore<Vector3, Vector3, VectorOptions> DisplayBubbled(this RectTransform self, float targetScale, float duration, float delay = 0f, float defaultScale = 1f, Action onComplete = null) => 
            DisplayBubbled(self.transform, targetScale, duration, delay, defaultScale, onComplete);
        
        public static TweenerCore<Vector3, Vector3, VectorOptions> DisplayBubbled(this Transform self, float targetScale, float duration, float delay = 0f, float defaultScale = 1f, Action onComplete = null) =>
            self
                .DOScale(targetScale, duration * 0.5f)
                .SetDelay(delay)
                .OnComplete(() => self
                    .DOScale(defaultScale, duration * 0.5f)
                    .OnComplete(() =>
                    {
                        onComplete?.Invoke();
                        onComplete = null;
                    }));
    }
}