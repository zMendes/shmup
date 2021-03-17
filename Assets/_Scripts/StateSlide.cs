using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSlide : State
{
    private float x, y;
    SteerableBehaviour steerable;
    GameManager gm;

    public void Start()
    {
        gm = GameManager.GetInstance();
        
        steerable = GetComponent<SteerableBehaviour>();

        x= Random.Range(-2,0);
        y = Random.Range(-1,1);

    }

    public override void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;


        //TODO: MOV QUANDO ATACANDO
        steerable.Thrust(x, y);


    }
}