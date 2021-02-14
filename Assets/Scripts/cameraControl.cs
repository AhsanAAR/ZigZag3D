﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class cameraControl : MonoBehaviour
{

    public GameObject ball;

    Vector3 offset;
    public float lerpRate;


    // Start is called before the first frame update
    void Start()
    {
        offset = ball.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver)
        {
            follow();
        }
        
    }

    void follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}