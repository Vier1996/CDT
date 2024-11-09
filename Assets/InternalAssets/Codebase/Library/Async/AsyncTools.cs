using UniRx;
using UnityEngine;

namespace InternalAssets.Codebase.Library.Async
{
    public static class AsyncTools
    {
        public static void GetCancellationPair(this object component, out ICancellationPair output)
        {
            output = Get();
        }

        public static void GetCancellationPair(this Component component, out ICancellationPair output)
        {
            output = Get();
            output.AddTo(component);
        }

        public static ICancellationPair GetNewCancellationPair() => Get();

        private static ICancellationPair Get()
        {
            return new CancellationPair();
        }
    }
}