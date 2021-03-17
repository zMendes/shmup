using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score 
{
    public string name;
    public float time;

    public string points;

    public Score( string name_, float time_, string points_){
        name = name_;
        time = time_;
        points = points_;
    }
}
