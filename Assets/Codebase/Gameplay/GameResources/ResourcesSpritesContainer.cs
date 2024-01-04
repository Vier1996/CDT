using System;
using System.Collections.Generic;
using System.Linq;
using Codebase.Extension;
using Codebase.Gameplay.Enums;
using UnityEngine;

namespace Codebase.Gameplay.GameResources
{
    [CreateAssetMenu(menuName = "App/Resource/" + nameof(ResourcesSpritesContainer), fileName = nameof(ResourcesSpritesContainer))]
    public class ResourcesSpritesContainer : LoadableScriptableObject<ResourcesSpritesContainer>
    {
        [SerializeField] private List<ResourcesSpritesData> _resourcesSprites = new();

        public ResourcesSpritesData GetResourceSpriteData(ResourceType resourceType)
        {
            ResourcesSpritesData data = _resourcesSprites.FirstOrDefault(rd => rd.ResourceType == resourceType);

            if (data == default)
                throw new ArgumentException($"Can not get setup for type:[{resourceType}]");
            
            return data;
        }
    }
    
    [Serializable]
    public class ResourcesSpritesData
    {
        public ResourceType ResourceType;
        public Sprite ResourceSprite;
    }
}