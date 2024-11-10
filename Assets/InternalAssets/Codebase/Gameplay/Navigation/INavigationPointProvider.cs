using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Navigation
{
    public interface INavigationPointProvider
    {
        public Vector3 GetAvailablePoint();
        public Vector3 GetAvailablePoint(Vector3 boxSize, float spawnOffset, bool checkVisible);
    }
}