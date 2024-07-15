using System;

namespace InternalAssets.Codebase.Gameplay.Workplaces.Data
{
    [Serializable]
    public class WorkData
    {
        public string WorkplaceId { get; private set; } = string.Empty;
        public string WorkerId { get; private set; } = string.Empty;
        public float Progress { get; private set; } = 0f;
    }
}