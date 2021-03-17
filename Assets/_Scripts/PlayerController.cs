using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    GameManager gm;
    
    Animator animator;

    public GameObject shot;
    public Transform gun;

    public AudioClip shotSFX;
    
    public float shootDelay = 0.1f;
    private float _lastShootTimestamp = 0.0f;


    
    private void Start()
    {
       animator = GetComponent<Animator>();

       gm = GameManager.GetInstance();
       
    }


    public void Shoot()
    {
        if ( Time.time - _lastShootTimestamp < shootDelay) 
            return;
        AudioManager.PlaySFX(shotSFX);
        _lastShootTimestamp = Time.time;
        Instantiate(shot, gun.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        gm.lifes--;
        if (gm.lifes <= 0) 
            Die();
    }


    public void Die()
    {
            
            
        animator.Play("Player_explosion");
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        CancelInvoke();
        gm.ChangeState(GameManager.GameState.ENDGAME);

    }

    void FixedUpdate()
    {   

        if (gm.gameState != GameManager.GameState.GAME) return;
        
        
        gm.time +=  Time.deltaTime;

        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
            gm.ChangeState(GameManager.GameState.PAUSE);
        
        if (yInput != 0 || xInput != 0)
            animator.SetFloat("Velocity", 1.0f);
        else
            animator.SetFloat("Velocity", 0.0f);

        if (Input.GetAxisRaw("Jump") != 0)
            Shoot();
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemies"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }

    

    
}
