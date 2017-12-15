using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpillmanGame { 
    public class GameManager {

        public enum GameMode
        {
            CAR,
            PLAYER,
            DEAD
        }

        private static GameManager instance = new GameManager();
        public GameMode ActiveGameMode { get; private set; }
        public bool LightsOn { get; set; }

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
            else if(ActiveGameMode == GameMode.PLAYER)
            {
                ActiveGameMode = GameMode.CAR;
            }
        }

        public void TriggerDeath()
        {
            ActiveGameMode = GameMode.DEAD;
            Debug.Log("You are dead!");
        }
    }
}
