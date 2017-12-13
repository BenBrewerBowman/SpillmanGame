using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpillmanGame { 
    public class GameManager {

        public enum GameMode
        {
            CAR,
            PLAYER
        }

        private static GameManager instance = new GameManager();
        public GameMode ActiveGameMode { get; private set; }

        private GameManager() {
            ActiveGameMode = GameMode.CAR;
        }

        public static GameManager GetInstance()
        {
            return instance;
        }

        public void ToggleGameMode()
        {
            if(ActiveGameMode == GameMode.CAR)
            {
                ActiveGameMode = GameMode.PLAYER;
            }
            else
            {
                ActiveGameMode = GameMode.CAR;
            }
        }
    }
}
