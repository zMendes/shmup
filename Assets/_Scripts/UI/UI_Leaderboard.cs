using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Firebase;
using UnityEngine.UI;
//using Firebase.Database;
using System.Linq;
using Proyecto26;



public class UI_Leaderboard : MonoBehaviour
{
    public Text[] text;
    public Text[] time;
    //DatabaseReference reference;
    //bool sorted = false;
    List<Score> list;
    List<Score> sortedList;

    GameManager gm;

    void GetLeaderboard(){
        RestClient.Get("https://space-domain-default-rtdb.firebaseio.com/scores.json").Then( response => {
            //Debug.Log(response.Text);
            //ScoreSerializable a = JsonUtility.FromJson<ScoreSerializable>(response.Text);
            //print(a);
            //print(a.scores[0].name);

            //Score score = JsonUtility.FromJson<Score>(response.Text);
            //Debug.Log("oi");
            ;}
        );
    }

    void OnEnable()
    {
        //sorted = false;
        sortedList = new List<Score>();
        gm = GameManager.GetInstance();

        GetLeaderboard();

        //reference = FirebaseDatabase.DefaultInstance.RootReference;
        
      /*  FirebaseDatabase.DefaultInstance
      .GetReference("scores")
      .GetValueAsync().ContinueWith(task => {
        if (task.IsFaulted) {
            print("uhhh");
          // Handle the error...
        }
        else if (task.IsCompleted) {
          DataSnapshot snapshot = task.Result;
          // Do something with snapshot...
          foreach ( DataSnapshot child in snapshot.Children){

              IDictionary data = (IDictionary)child.Value;
              Score score = new Score(  data["name"].ToString(),  float.Parse(data["time"].ToString()), data["points"].ToString());
              list.Add(score);
          }
        }
      });*/

        }


    void Update(){
        if (list != null){
            print(list.Count);
        }
        /*if (list.Count != 0){
            if (!sorted){
                sortedList = list.OrderByDescending(o=> o.time).ToList();
                sorted = true;
            }
            else{
                for (int i=0;i<5;i++){
                    text[i].text = sortedList[i].name; 
                    time[i].text = sortedList[i].time.ToString("#.##");

                }
            }
        }
*/
    }
    
    public void Home()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }

}
