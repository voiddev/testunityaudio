using UnityEngine;

using Scripts.Utils;
using State = Scripts.Game.GameState.State;


namespace Scripts.Game {

    public class GameManager : GameComponentSingleton<GameManager> {

        public GameState state = new GameState(State.INIT);

        protected GameManager() {
        }

        void OnComponentInstantiated() {
            InitGame();
            InitScene();
        }


        void InitGame() {
            if (state == null) {
                LOG.Info("Initialize the game...");
                // do initialization stuff
                LOG.Info("Initialization has been done");
                state = new GameState(State.INTRO);
            }

        }

        void InitScene() {
            LOG.Info("Initialize scene ");
        }

        void Update () {

        }



    }
}