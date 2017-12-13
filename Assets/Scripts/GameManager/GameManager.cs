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
    private GameMode gameMode { get; private set; }

    private GameManager() {
        gameMode = GameMode.PLAYER;
    }

    public GameManager GetInstance()
    {
        return instance;
    }

    public ToggleGameMode()
    {
        if(GameMode == GameMode.CAR)
        {
            gameMode = GameMode.PLAYER;
        }
    }
}
