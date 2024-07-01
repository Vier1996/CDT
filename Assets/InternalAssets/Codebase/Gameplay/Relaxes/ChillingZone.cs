using InternalAssets.Codebase.Library.Areas;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Relaxes
{
    public class ChillingZone : RelaxPoint
    {
        public Vector3 ChillingPoint => _area.GetRandomPosition();
        
        [SerializeField] private Area _area;
        
        private void Start()
        {
            InitializeEntity();
        }

        public bool InBounds(Vector3 position) => _area.InBounds(position);
    }
}