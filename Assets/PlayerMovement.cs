using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// The width of the lane
    /// </summary>
    public float laneWidth = 1;
    /// <summary>
    /// Gravity being applied to the character
    /// </summary>
    const int GRAVITY = -9;
    /// <summary>
    /// Velocity, set later in the code
    /// </summary>
    Vector3 velocity;
    /// <summary>
    /// Lane player is currently in
    /// </summary>
    int lane = 0;
    public int health = 5;
    SceneController scenecontroller;

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
        if (transform.position.y < 1) // on gorund
        {
            Vector3 pos = transform.position; //make a copy of the pos
            pos.y = 1; // clamp y value
            transform.position = pos;
        }

        float targetX = (lane * laneWidth) / 2;

        float x = (targetX - transform.position.x) * .1f;
        transform.position += new Vector3(x, 0, 0);
        //Squash and stretch
        Vector3 scale = transform.localScale;
        if (Input.GetButton("SquishSkinny"))
        {
            scale.x = Mathf.Lerp(scale.x, (scale.x >= 0 ? .2f : 3), Time.deltaTime);
            scale.x = Mathf.Lerp(scale.x, (scale.x <= 3 ? 1.5f : 3), Time.deltaTime);
        }
        else
        {
            scale.x = Mathf.Lerp(scale.x, (scale.x <= 3 ? 3 : 3), Time.deltaTime);
        }
        if (Input.GetButton("SquishFlat"))
        {
            print("i'm bring sexy back");
            scale.y = Mathf.Lerp(scale.y, (scale.y >= 0 ? .2f : 3), Time.deltaTime);
        }
        else
        {
            scale.y = Mathf.Lerp(scale.y, (scale.y <= 3 ? 3 : 3), Time.deltaTime);
        }
        transform.localScale = scale;

      }
    /// <summary>
    /// Decides what to do depending on what the tag and type is
    /// </summary>
    /// <param name="other">The overlappin object</param>
    void OverlappingAABB(AABB other)
    {

        if (other.tag == "Powerup")
        {
            // it must be a powerup...
            PowerUp powerup = other.GetComponent<PowerUp>();
            switch (powerup.type)
            {

               case PowerUp.Type.Slowmo:
                    scenecontroller.rotSpeed += .2f;
                    break;
                case PowerUp.Type.Health:
                    if (health < 4)
                    {
                        health += 1;
                        print(health);
                    }
                    break;
                case PowerUp.Type.Negative:
                    if (health > 0)
                    {
                        health -= 1;
                        print(health);
                    }
                    else if (health == 0)
                    {
                        SceneManager.LoadScene("Lose");
                    }
                    break;
                //case PowerUp.Type.JetpackBoost:
                // break;
                case PowerUp.Type.None:
                    break;
            }
            Destroy(other.gameObject);
        }
    }
     
}
