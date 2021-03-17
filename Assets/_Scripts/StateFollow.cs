using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFollow : State
{
  public Transform waypoint;  
  SteerableBehaviour steerable;
  
  GameManager gm;


 
  public override void Awake()
  {
      base.Awake();      
      steerable = GetComponent<SteerableBehaviour>();

  }

  public void Start()
  {
      gm = GameManager.GetInstance();
      waypoint.position = GameObject.FindWithTag("Player").transform.position;
  }

  public override void Update()
  {
      if (gm.gameState != GameManager.GameState.GAME) return;

      Vector3 direction = waypoint.position - transform.position;
      direction.Normalize();
      steerable.Thrust(direction.x, direction.y);
      waypoint.position = GameObject.FindWithTag("Player").transform.position;
  }
 
}