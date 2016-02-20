using System;
using UnityEngine;

namespace Scripts.Utils {

    public class GameComponent : MonoBehaviour {

        public static Logger LOG = new Logger(typeof(GameComponent).Name);

        private GameComponent instance;

        void Awake() {
            if (instance == null) {
                instance = this;
                OnComponentInstantiated();
            } else if (instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);

        }

        protected void  OnComponentInstantiated() {
        }

    }
}