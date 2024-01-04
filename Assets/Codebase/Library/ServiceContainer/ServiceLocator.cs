using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Codebase.Library.ServiceContainer
{
    public class ServiceLocator : MonoBehaviour
    {
        private static ServiceLocator global;
        private static Dictionary<Scene, ServiceLocator> sceneContainers;
        
        private readonly ServiceManager services = new ServiceManager();
        private static List<GameObject> tmpSceneGameObjects;

        const string k_globalServiceLocatorName = "ServiceLocator [Global]";
        const string k_sceneServiceLocatorName = "ServiceLocator [Scene]";

        internal void ConfigureAsGlobal(bool dontDestroyOnLoad)
        {
            if (global == this)
            {
                Debug.LogWarning($"ServiceLocator.ConfigureAsGlobal: Already configured as global", this);
            } else if (global != null)
            {
                Debug.LogWarning($"ServiceLocator.ConfigureAsGlobal: Another ServiceLocator is already configured as global", this);
            }
            else
            {
                global = this;

                if (dontDestroyOnLoad)
                    DontDestroyOnLoad(gameObject);
            }
        }

        internal void ConfigureForScene()
        {
            Scene scene = gameObject.scene;

            if (sceneContainers.ContainsKey(scene))
            {
                Debug.LogWarning($"ServiceLocator.ConfigureForScene: Another ServiceLocator is already configured for this scene", this);
                return;
            }
            
            sceneContainers.Add(scene, this);
        }
        
        public static ServiceLocator Global
        {
            get
            {
                if (global != null) return global;

                if (FindFirstObjectByType<ServiceLocatorGlobalBootstrapper>() is { } found)
                {
                    found.BootstrapOnDemand();

                    return global;
                }

                GameObject container = new GameObject(k_globalServiceLocatorName, typeof(ServiceLocator));

                container.AddComponent<ServiceLocatorGlobalBootstrapper>().BootstrapOnDemand();

                return global;
            }
        }

        public static ServiceLocator For(MonoBehaviour behaviour)
        {
            return behaviour.GetComponentInParent<ServiceLocator>() == null ? ForSceneOf(behaviour) : Global;
        }

        public static ServiceLocator ForSceneOf(MonoBehaviour behaviour)
        {
            Scene scene = behaviour.gameObject.scene;

            if (sceneContainers.TryGetValue(scene, out ServiceLocator containers) && containers != behaviour)
            {
                return containers;
            }
            
            tmpSceneGameObjects.Clear();
            scene.GetRootGameObjects(tmpSceneGameObjects);

            foreach (GameObject go in tmpSceneGameObjects.Where(go => go.GetComponent<ServiceLocatorSceneBootstrapper>() != null))
            {
                if (go.TryGetComponent(out ServiceLocatorSceneBootstrapper bootstrapper) && bootstrapper.Container != behaviour)
                {
                    bootstrapper.BootstrapOnDemand();
                    return bootstrapper.Container;
                }
            }

            return Global;
        }

        public ServiceLocator Register<T>(T service)
        {
            services.Register(service);
            return this;
        }
        
        public ServiceLocator Register(Type type, object service)
        {
            services.Register(type, service);
            return this;
        }

        public ServiceLocator Get<T>(out T service) where T : class
        {
            if (TryGetService(out service)) return this;

            if (TryGetNextInHierarchy(out ServiceLocator container))
            {
                container.Get(out service);
                return this;
            }

            throw new ArgumentException($"ServiceLocator.Get: Service of type {typeof(T).FullName} not registered");
        }
        
        public bool TryGetService<T>(out T service) where T : class
        {
            return services.TryGet(out service);
        }

        public bool TryGetNextInHierarchy(out ServiceLocator container)
        {
            if (this == global)
            {
                container = null;
                return false;
            }

            if (transform.parent != null)
            {
                ServiceLocator nextLocator = transform.parent.GetComponentInParent<ServiceLocator>();

                if (nextLocator != null)
                {
                    container = nextLocator;
                }
                else
                {
                    container = ForSceneOf(this);
                }
            }
            else
            {
                container = null;
            }

            return container != null;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void ResetStatics()
        {
            global = null;
            sceneContainers = new Dictionary<Scene, ServiceLocator>();
            tmpSceneGameObjects = new List<GameObject>();
        }

        private void OnDestroy()
        {
            if (this == global)
                global = null;
            else if (sceneContainers.ContainsValue(this))
            {
                sceneContainers.Remove(gameObject.scene);
            }
        }

#if UNITY_EDITOR
        
        [MenuItem("GameObjet/ServiceLocator/Add Global")]
        static void AddGlobal()
        {
            var go = new GameObject(k_globalServiceLocatorName, typeof(ServiceLocatorGlobalBootstrapper));
        }
        
        [MenuItem("GameObjet/ServiceLocator/Add Scene")]
        static void AddScene()
        {
            var go = new GameObject(k_sceneServiceLocatorName, typeof(ServiceLocatorSceneBootstrapper));
        }
        
#endif
    }
}