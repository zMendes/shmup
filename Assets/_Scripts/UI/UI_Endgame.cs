using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Firebase;
//using Firebase.Database;
using Proyecto26;


public class UI_Endgame : MonoBehaviour
{
   public Text message;
   public GameObject player;

   public InputField nickname;

   //DatabaseReference reference;

    GameManager gm;
   private void OnEnable()
   {
       gm = GameManager.GetInstance();


       //reference = FirebaseDatabase.DefaultInstance.RootReference;

       message.text = $"Time: { ((int) gm.time).ToString()} seconds" ;

   }
   
    public void Home()
    {
        gm.ChangeState(GameManager.GameState.MENU);

    }


    public void OnSubmit()
    {
        Score a = new Score(nickname.text, gm.time, 22.ToString());

       string json = JsonUtility.ToJson(a);

       //reference.Child("scores").Child(nickname.text).SetRawJsonValueAsync(json)    ;
       RestClient.Post("https://space-domain-default-rtdb.firebaseio.com/scores.json", json);


    }
}