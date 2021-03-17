﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menu : MonoBehaviour
{
    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void Comecar(){

        gm.ChangeState(GameManager.GameState.GAME);
        gm.Reset();

        
    }

    public void Leaderboard(){

        gm.ChangeState(GameManager.GameState.LEADERBOARD);
    }
}
