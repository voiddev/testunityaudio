using UnityEngine;

namespace Scripts.Utils {

    public class GameComponentSingleton<T> : MonoBehaviour where T : MonoBehaviour {

        private static T _instance;

        public static Logger LOG = new Logger(typeof(T).Name);

        private static bool componentIsLoaded = false;

        private static object _lock = new object();

        private static bool applicationIsQuitting = false;


        public static T Instance {
            get {

                if (applicationIsQuitting) {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                    "' already destroyed on application quit. Won't create again - returning null.");
                    return null;
                }

                lock (_lock) {
                    if (_instance == null) {
                        _instance = (T) FindObjectOfType(typeof(T));

                        if ( FindObjectsOfType(typeof(T)).Length > 1 ) {
                            Debug.LogError("[Singleton] Something went really wrong " +
                            " - there should never be more than 1 singleton! Reopening the scene might fix it.");
                            return _instance;
                        }

                        if (_instance == null) {
                            GameObject singleton = new GameObject();
                            _instance = singleton.AddComponent<T>();
                            singleton.name = "(singleton) " + typeof(T).ToString();

                            DontDestroyOnLoad(singleton);

                            Debug.Log("[Singleton] An instance of " + typeof(T) +
                            " is needed in the scene, so '" + singleton + "' was created with DontDestroyOnLoad.");
                        } else {
                            Debug.Log("[Singleton] Using instance already created: " +
                            _instance.gameObject.name);
                        }
                    }

                    return _instance;
                }
            }
        }

        public GameComponentSingleton<T> Load() {
            return this;
        }

        public void OnDestroy () {
            applicationIsQuitting = true;
        }
    }
}