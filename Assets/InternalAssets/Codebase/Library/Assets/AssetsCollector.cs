﻿using System.Collections.Generic;
using UnityEditor;

namespace InternalAssets.Codebase.Library.Assets
{
    public static class AssetsCollector
    {
        public static bool TryGetAssets<T>(out List<T> outputList) where T : class
        {
            outputList = new();
            
#if UNITY_EDITOR
            foreach (string guid in AssetDatabase.FindAssets($"t:{typeof(T)}"))
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);

                if (AssetDatabase.LoadAssetAtPath(path, typeof(T)) is T asset) 
                    outputList.Add(asset);
            }
#endif
            
            return outputList.Count > 0;
        }
    }
}