using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

    public enum GameMode
    {
        CAR,
        PLAYER
    }

    private static GameManager instance = new GameManager();
    public GameMode gameMode { get; private set; }

    private GameManager() {
        gameMode = GameMode.PLAYER;
    }

    public GameManager GetInstance()
    {
        return instance;
    }

    public void ToggleGameMode()
    {
        if(gameMode == GameMode.CAR)
        {
            gameMode = GameMode.PLAYER;
        }
        else
        {
            gameMode = GameMode.CAR;
        }
    }
}
