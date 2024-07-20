using System;
using System.IO;
using Cysharp.Threading.Tasks;
using InternalAssets.Codebase.Library.Random;
using InternalAssets.Codebase.Library.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace InternalAssets.Codebase.Library.Extension
{
    public abstract class LoadableScriptableObject<T> : SerializedScriptableObject where T : SerializedScriptableObject
    {
        private const string ResourcePath = "ScriptableObjects/";

        private static T _cachedInstance = null;
        private static int _referenceCount = 0;
        private static bool _isNotReleasable = false;
        private static string _path = null;
        private static ResourceRequest _loadRequest = null;

        public static async UniTask<T> GetInstanceAsync(bool canBeReleased = true)
        {
            _isNotReleasable = !canBeReleased;
            _referenceCount++;

            if (_cachedInstance != null) return _cachedInstance;
            
            await (_loadRequest ??= UnityEngine.Resources.LoadAsync<T>(GetPath()));

            _cachedInstance = (T)_loadRequest.asset;

            if (_cachedInstance == null)
                throw new FileLoadException($"Can not load <SO> with type:[{typeof(T).Name}] by resource path:[{GetPath()}]");

            return _cachedInstance;
        }

        public static T GetInstance(bool canBeReleased = true)
        {
            _isNotReleasable = !canBeReleased;
            _referenceCount++;

            if (_cachedInstance != null) return _cachedInstance;
            
            if ((_cachedInstance = UnityEngine.Resources.Load<T>(GetPath())) == null)
                throw new FileLoadException($"Can not load <SO> with type:[{typeof(T).Name}] by resource path:[{GetPath()}]");

            return _cachedInstance;
        }

        public static T ReleaseInstance()
        {
            if (_isNotReleasable)
                return null;

            _referenceCount--;

            if (_referenceCount <= 0 && _cachedInstance != null)
            {
                UnityEngine.Resources.UnloadAsset(_cachedInstance);
                _cachedInstance = null;
                _loadRequest = null;
            }

            return null;
        }

        public static void ClearAllReferences()
        {
            if (_isNotReleasable)
                return;

            _referenceCount = 0;

            if (_cachedInstance != null)
            {
                UnityEngine.Resources.UnloadAsset(_cachedInstance);
                _cachedInstance = null;
                _loadRequest = null;
            }
        }

        public void Release() => ReleaseInstance();

        private static string GetPath()
        {
            if (_path != null) return _path;

            Type selfType = typeof(T);
            
            _path += ResourcePath;
            
            if (selfType.TryGetAttribute(out LoadablePathAttribute attribute))
                _path += attribute.DirectoryPath + "/";

            _path += selfType.Name;

            return _path;
        }
    }

    public class LoadablePathAttribute : Attribute
    {
        public string DirectoryPath { get; private set; }

        public LoadablePathAttribute(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }
    }
}