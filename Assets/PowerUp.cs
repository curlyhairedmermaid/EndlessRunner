using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	// Use this for initialization
    float speed = -10;
    public float laneWidth = 2;
    int lane = 0;
    float life = 0;

    // Use this for initialization
    void Start()
    {
        print("jike");
        lane = Random.Range(-2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;

        float targetX = lane * laneWidth;
        life = life + Time.deltaTime;
        float x = (targetX - transform.position.x) * .1f;
        transform.position += new Vector3(x, 0, 0);
        if (life >= 4)
        {
            Destroy(this);
        }
        /*
        if (collision is true)
        {
            ObstacleMovement.ObstacleSpeed *= 2;
        }
        */
    }
}
