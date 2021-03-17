using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
    private static GameManager _instance;

    public enum GameState {MENU, GAME, PAUSE, ENDGAME, LEADERBOARD}
    
    public GameState gameState { get; private set; }
    public int points;
    public int lifes;
    public float time;

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;


    public static GameManager GetInstance()
    {
        if (_instance == null)
            _instance = new GameManager();
        return _instance;
    }

    private GameManager()
    {
        points = 0;
        lifes = 10;
        gameState = GameState.MENU;
        time = 0;
    }

    public void ChangeState(GameState nextState)
    {
        gameState = nextState;
        changeStateDelegate();
    }

    public void Reset()
    {
        points = 0;
        lifes = 10;
        time = 0;
    }




}
