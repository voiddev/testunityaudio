using Scripts.Utils;
using UnityEngine;
using Logger = Scripts.Utils.Logger;

namespace Scripts.Game {

    public class GameState {
        public enum State {
            INIT,
            INTRO,
            GAME,
            PAUSE
        }

        public static Logger LOG = new Logger("GameState");

        private State current;

        public GameState(State state) {
            SetState(state);
        }

        public void SetState(State state) {
            current = state;
        }
    }
}