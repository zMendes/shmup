﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    GameObject player;
    // Update is called once per frame
    void Update()
    {   
        player = GameObject.FindWithTag("Player");;
        if (player == null) return;

        transform.position = new Vector3 (player.transform.position.x + 3.5f, transform.position.y, transform.position.z);
        
    }
}
