using System;
using System.Threading;
using UniRx;

namespace InternalAssets.Codebase.Library.Async
{
    public interface ICancellationPair : IDisposable
    {
        public CancellationTokenSource Source { get; }
        public CancellationToken Token => Source.Token;
        public bool IsDisposed { get; }
    }
    
    public class CancellationPair : ICancellationPair
    {
        private readonly Subject<CancellationPair> _disposed = new();

        public CancellationTokenSource Source 
        {
            get => _source;
            private set => _source = value;
        }
        public CancellationToken Token => Source.Token;

        public bool IsDisposed { get; private set; }

        private CancellationTokenSource _source = new();
        
        public void Dispose()
        {
            if (IsDisposed) return;

            IsDisposed = true;
            
            _source.Cancel();
            _source.Dispose();
            
            _disposed?.OnNext(this);
        }
    }
}