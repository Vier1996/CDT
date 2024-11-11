using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using InternalAssets.Codebase.Library.Async;
using UnityEngine;

namespace InternalAssets.Codebase.Library.Extension
{
    public static class TweenExtensions
    {
        public static Component KillTween(this Component component)
        {
            component.DOPause();
            component.DOKill();
            return component;
        }
        
        public static T KillTween<T>(this Component component) where T : class
        {
            component.DOPause();
            component.DOKill();
            return component as T;
        }

        public static Material KillTween(this Material material)
        {
            material.DOPause();
            material.DOKill();
            return material;
        }
        
        public static UniTask ToUniTask(this DG.Tweening.Tween tween, ICancellationPair cancellationPair = null) => 
            tween.ToUniTask(cancellationPair?.Token ?? default);

        public static UniTask ToUniTask(this DG.Tweening.Tween tween, CancellationToken token = default)
        {
            UniTask task = tween
                .AsyncWaitForCompletion()
                .AsUniTask();
            
            return token != default 
                ? task.AttachExternalCancellation(token)
                : task;
        }
    }
}