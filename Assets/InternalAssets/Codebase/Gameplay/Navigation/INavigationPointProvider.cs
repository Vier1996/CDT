using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Navigation
{
    public interface INavigationPointProvider
    {
        public Vector3 GetAvailablePoint();
    }
}