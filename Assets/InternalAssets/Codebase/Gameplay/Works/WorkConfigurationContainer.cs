using System;
using System.Collections.Generic;
using System.Linq;
using InternalAssets.Codebase.Gameplay.Enums;
using InternalAssets.Codebase.Library.Extension;
using UnityEngine;

namespace InternalAssets.Codebase.Gameplay.Works
{
    [CreateAssetMenu(menuName = "App/Work/" + nameof(WorkConfigurationContainer), fileName = nameof(WorkConfigurationContainer))]
    public class WorkConfigurationContainer : LoadableScriptableObject<WorkConfigurationContainer>
    {
        [SerializeField] private List<WorkConfig> _workConfigs = new List<WorkConfig>();

        public WorkConfig GetConfig(WorkType workType)
        {
            WorkConfig config = _workConfigs.FirstOrDefault(wc => wc.WorkType == workType);

            if (config == default)
                throw new ArgumentException($"Can not get config with type:[{workType}]");

            return config;
        }
    }
}