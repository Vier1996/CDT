using InternalAssets.Codebase.Gameplay.Enums;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Works
{
    [CreateAssetMenu(menuName = "App/Work/" + nameof(WorkConfig), fileName = nameof(WorkConfig))]
    public class WorkConfig : ScriptableObject
    {
        public WorkType WorkType;
        
        public bool CanBeRecoverAfterGameLoading = false;
        public bool CanBeIntercepted = true;
        
        public float WorkDuration;
    }
}