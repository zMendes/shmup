using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{

    public GameObject shot;
    public AudioClip shotSFX;


    GameManager gm;

    public void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void Shoot()
    {
        if (shotSFX != null) AudioManager.PlaySFX(shotSFX);
        Instantiate(shot, transform.position, Quaternion.identity);
        //throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    //float angle = 0;

    private void FixedUpdate()
    {
        if (gm.gameState == GameManager.GameState.PAUSE) return;
       
    }
}
