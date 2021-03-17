using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAtaqueWaypoint : State
{
    SteerableBehaviour steerable;
    IShooter shooter;
    GameManager gm;

    public float distance = 2.0f;

    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    public override void Awake()
    {
        base.Awake();

        if (GameObject.FindWithTag("Player") == null) return;
        Transition patrol = new Transition();
        patrol.condition = new ConditionDistGT(transform, GameObject.FindWithTag("Player").transform, distance);
        patrol.target = GetComponent<StatePatrulhaPorWaypoints>();


        transitions.Add(patrol);


        steerable = GetComponent<SteerableBehaviour>();
        shooter = steerable as IShooter;
        if (shooter == null)    throw new MissingComponentException("Este GameObject não implementa IShooter");
    }

    public void Start()
    {
        gm = GameManager.GetInstance();
    }

    public override void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        //TODO: MOV QUANDO ATACANDO

        if (Time.time - _lastShootTimestamp < shootDelay) return;
        _lastShootTimestamp = Time.time;
        shooter.Shoot();
    }
}
