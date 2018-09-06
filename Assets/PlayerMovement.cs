using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public float laneWidth = 1;
    const int GRAVITY = -9;
    new Vector3 velocity;
    int lane = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Horizontal"))
        {
            if (h == -1) // if pressing left
            {
                lane--;
            }
            else if (h == 1) // if pressing right
            {
                lane++;
            }
            lane = Mathf.Clamp(lane, -2, 2);
        }
        // Apply GRAVITY:
        velocity += new Vector3(0, GRAVITY, 0) * Time.deltaTime;

        if (Input.GetButtonDown("Jump")) // press space
        {
            if (transform.position.y <= 0) //on ground
            {
                velocity.y = 7; //jump
            }
        }
        // Euler shit
        transform.position += velocity * Time.deltaTime;
        if (transform.position.y < 0) // on gorund
        {
            Vector3 pos = transform.position; //make a copy of the pos
            pos.y = 0; // clamp y value
            transform.position = pos;
        }

        float targetX = (lane * laneWidth) / 2;

        float x = (targetX - transform.position.x) * .1f;
        transform.position += new Vector3(x, 0, 0);



    }
}
