using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    /// <summary>
    /// The health of the player
    /// </summary>
    public int health = 5;
    /// <summary>
    /// Our text object for the players health being rendered to the screen
    /// </summary>
    public Text healthy;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        healthy.text = "Health: " + health.ToString();
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

            if (transform.position.y <= 1.5) //on ground
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
                case PowerUp.Type.Health:
                    if (health < 5)
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
                case PowerUp.Type.None:
                    break;
            }
            Destroy(other.gameObject);
        }
    }

}
