using InternalAssets.Codebase.Library.Areas;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Relaxes
{
    public class SleepingZone : RelaxPoint
    {
        public Vector3 SleepingPoint => _area.GetRandomPosition();
        
        [SerializeField] private Area _area;
        
        private void Start()
        {
            //InitializeEntity();
        }
    }
}