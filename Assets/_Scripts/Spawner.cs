using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] myObjects;

    public GameObject player;
    GameManager gm;
    
    public float spawnTime = 6f;            // How long between each spawn.

  

  void Start()
  {
      gm = GameManager.GetInstance();
      GameManager.changeStateDelegate += Construir;
      Construir();

      InvokeRepeating ("SpawnRandom", spawnTime, spawnTime);


  }

  void Construir()
  {
     
       if (gm.gameState == GameManager.GameState.MENU)
      {
            float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
 
            Vector2 spawnPosition = new Vector2(spawnX, spawnY);

          Instantiate(myObjects[0],  new Vector3(Random.Range(-spawnX, spawnX),Random.Range(-spawnY, spawnY),0), Quaternion.identity, transform);
          Instantiate(myObjects[1],  new Vector3(Random.Range(-spawnX, spawnX),Random.Range(-spawnY, spawnY),0), Quaternion.identity, transform);
          Instantiate(myObjects[2],  new Vector3(Random.Range(-spawnX, spawnX),Random.Range(-spawnY, spawnY),0), Quaternion.identity, transform);

      }
    }
  
    void spawnPlayer()
    {
        Instantiate(player);
        //Instantiate(player, new Vector3(0,0,0), Quaternion.identity, transform);
    }

  void SpawnRandom()
  {
      
      if (gm.gameState != GameManager.GameState.GAME) return;
      
    Vector2 screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    for (int i =0; i<Random.Range(0,3);i++){
    Instantiate(myObjects[Random.Range(0,myObjects.Length)],  new Vector3(Random.Range(screen.x, screen.x + 2),Random.Range(-screen.y, screen.y),0), Quaternion.identity, transform);}
      
    }


      void Update()
      {
          if (gm.gameState != GameManager.GameState.GAME && gm.gameState != GameManager.GameState.PAUSE ){
              foreach (Transform child in transform) {
              GameObject.Destroy(child.gameObject);
          }
        }

    if (GameObject.FindWithTag("Player") == null && gm.gameState == GameManager.GameState.GAME)
        spawnPlayer();      
    }
  }

