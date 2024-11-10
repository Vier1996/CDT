using System;
using System.Collections.Generic;
using InternalAssets.Codebase.Library.Random;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Navigation
{
    public class NavigationService : INavigationService, INavigationServiceConstructor, IDisposable
    {
        private readonly List<NavigationPoint> _navigationPoints;
        private readonly List<INavigationPointProvider> _providers;
        
        public NavigationService()
        {
            _navigationPoints = new List<NavigationPoint>();
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

        public void BindPoint(NavigationPoint point)
        {
            if(_navigationPoints.Contains(point) == false)
                _navigationPoints.Add(point);
        }

        public void UnbindPoint(NavigationPoint point)
        {
            if(_navigationPoints.Contains(point))
                _navigationPoints.Remove(point);
        }

        public bool TryGetPoint(Vector3 inputPosition, out Vector3 outputPoint)
        {
            outputPoint = default;
            
            foreach (var provider in _providers)
            {
                outputPoint = provider.GetAvailablePoint(inputPosition, 0f, false);

                if (outputPoint.Equals(default) == false)
                    return true;
            }

            return false;
        }

        public bool TryGetRandomPoint(out Vector3 outputPoint)
        {
            outputPoint = default;
            
            int limit = 15;

            while (limit > 0)
            {
                if (_providers.Count <= 0)
                {
                    limit--;
                    continue;
                }
                
                outputPoint = _providers.Random().GetAvailablePoint();

                if (outputPoint.Equals(default) == false)
                    return true;
                
                limit--;
            }

            return false;
        }

        public bool TryGetPointById(string id, out Vector3 outputPoint)
        {
            outputPoint = Vector3.zero;
            
            return false;
        }
    }

    public interface INavigationService
    {
        public bool TryGetPoint(Vector3 inputPosition, out Vector3 outputPoint);
        public bool TryGetRandomPoint(out Vector3 outputPoint);
        public bool TryGetPointById(string id, out Vector3 outputPoint);
    }
    
    public interface INavigationServiceConstructor
    {
        public void BindProvider(INavigationPointProvider provider);
        public void UnbindProvider(INavigationPointProvider provider);
        
        public void BindPoint(NavigationPoint point);
        public void UnbindPoint(NavigationPoint point);
    }
}