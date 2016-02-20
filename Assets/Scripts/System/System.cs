using Scripts.Game;
using UnityEngine;

namespace Scripts.System {
    public class System : MonoBehaviour {

        public GameObject gameManagerPrefab;

        void Awake() {
            if (gameManagerPrefab == null) {
                Instantiate(gameManagerPrefab);
            }
        }
    }
}