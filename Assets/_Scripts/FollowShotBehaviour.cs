using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShotBehaviour : SteerableBehaviour
{
    private Vector3 direction;
    Vector3 posPlayer;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemies")) return;

        IDamageable damageable = collision.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damageable is null))
            damageable.TakeDamage();
        
        Destroy(gameObject);
    }

    void Start()
    {
        posPlayer = GameObject.FindWithTag("Player").transform.position;
        direction = (posPlayer - transform.position).normalized;
    }

    void Update()
    {
        if (GameObject.FindWithTag("Player") == null) return;
        posPlayer = GameObject.FindWithTag("Player").transform.position;
        
        direction = (posPlayer - transform.position).normalized;

        Thrust(direction.x, direction.y);
    }


}
