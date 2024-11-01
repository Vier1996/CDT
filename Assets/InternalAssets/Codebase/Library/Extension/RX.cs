using System;
using UniRx;
using UnityEngine;

namespace InternalAssets.Codebase.Library.Extension
{
    public static class RX
    {
        public static IDisposable LoopedTimer(float initialDelay, float interval, Action callback) =>
            Observable
                .Timer(TimeSpan.FromSeconds(initialDelay), TimeSpan.FromSeconds(interval))
                .Subscribe(_ => callback?.Invoke());

        public static IDisposable CountedTimer(float initialDelay, float interval, int repeatingCount, Action callback,
            Action totalCompleteCallback = null) =>
            Observable
                .Timer(TimeSpan.FromSeconds(initialDelay), TimeSpan.FromSeconds(interval))
                .Take(repeatingCount)
                .Subscribe(_ => callback?.Invoke(), () => totalCompleteCallback?.Invoke());

        public static IDisposable Delay(float delay, Action callback, bool withNativeTimescale = true) =>
            Observable
                .Timer(TimeSpan.FromSeconds(delay), TimeSpan.FromSeconds(0), withNativeTimescale ? Scheduler.MainThread : Scheduler.MainThreadIgnoreTimeScale)
                .Take(1)
                .Subscribe(_ => callback?.Invoke());

        public static IObservable<float> DoValue(float from, float to, float duration, Action onComplete = null) =>
            Observable.Create<float>(observer =>
            {
                float startTime = Time.realtimeSinceStartup;
                float progress = 0.0f;

                void UpdateProgress()
                {
                    float elapsed = Time.realtimeSinceStartup - startTime;
                    progress = Mathf.Clamp01(elapsed / duration);

                    if (progress >= 1.0f)
                    {
                        observer.OnNext(to);
                        observer.OnCompleted();
                    }
                    else
                    {
                        observer.OnNext(Mathf.Lerp(from, to, progress));
                    }
                }

                UpdateProgress();

                return new CompositeDisposable
                {
                    Observable.EveryUpdate().Subscribe(_ => UpdateProgress()),
                    Disposable.Create(() => onComplete?.Invoke())
                };
            });

        public static IObservable<long> DoValue(long from, long to, float duration, Action onComplete = null) =>
            Observable.Create<long>(observer =>
            {
                float startTime = Time.time;
                float progress = 0.0f;
                float step = to - from;

                void UpdateProgress()
                {
                    progress = Mathf.Clamp01((Time.time - startTime) / duration);

                    if (progress >= 1.0f)
                    {
                        observer.OnNext(to);
                        observer.OnCompleted();
                    }
                    else
                    {
                        observer.OnNext(from + (long)(step * progress));
                    }
                }

                UpdateProgress();

                return new CompositeDisposable
                {
                    Observable.EveryUpdate().Subscribe(_ => UpdateProgress()),
                    Disposable.Create(() => onComplete?.Invoke())
                };
            });
    }
}