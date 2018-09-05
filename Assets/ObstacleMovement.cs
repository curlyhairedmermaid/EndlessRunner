﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    float ObstacleSpeed = -10;
    public float laneWidth = 2;
    int lane = 0;
    float life = 0;

    // Use this for initialization
    void Start()
    {
        lane = Random.Range(-2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, ObstacleSpeed) * Time.deltaTime;

        float targetX = lane * laneWidth;
        life = life + Time.deltaTime;
        float x = (targetX - transform.position.x) * .1f;
        transform.position += new Vector3(x, 0, 0);
        if (life >= 4)
        {
            Destroy(this);
        }
        if (Input.GetButtonDown("Vertical"))
        {
            ObstacleSpeed *= 2;
        }
    }
}
