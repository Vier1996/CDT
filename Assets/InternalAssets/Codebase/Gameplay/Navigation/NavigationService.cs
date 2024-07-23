using System;
using System.Collections.Generic;
using InternalAssets.Codebase.Library.Random;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Navigation
{
    public class NavigationService : INavigationService, INavigationServiceConstructor, IDisposable
    {
        private readonly List<INavigationPointProvider> _providers;
        
        public NavigationService()
        {
            _providers = new List<INavigationPointProvider>();
        }
        
        public void Dispose() => _providers.Clear();

        public void BindProvider(INavigationPointProvider provider)
        {
            if(_providers.Contains(provider) == false)
                _providers.Add(provider);
        }

        public void UnbindProvider(INavigationPointProvider provider)
        {
            if(_providers.Contains(provider))
                _providers.Remove(provider);
        }

        public bool TryGetRandomPoint(out Vector3 outputPoint)
        {
            outputPoint = default;
            
            int limit = 15;

            while (limit > 0)
            {
                outputPoint = _providers.Random().GetAvailablePoint();

                if (outputPoint.Equals(default) == false)
                    return true;
                
                limit--;
            }

            return false;
        }
    }

    public interface INavigationService
    {
        public bool TryGetRandomPoint(out Vector3 outputPoint);
    }
    
    public interface INavigationServiceConstructor
    {
        public void BindProvider(INavigationPointProvider provider);
        public void UnbindProvider(INavigationPointProvider provider);
    }
}