using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    /// <summary>
    /// The health of the player
    /// </summary>
    public int health = 5;
    /// <summary>
    /// the speed of the powerup
    /// </summary>
    int speed = -10;
    /// <summary>
    /// How long the Powerup had been alive
    /// </summary>
    float life = 0;
    /// <summary>
    /// Setting the different types of Powerups
    /// </summary>
    public enum Type // Powerup.Type
    {
        
       //Slowmo,
        Health,
       // JetpackBoost,
        Negative,
        None
    }
    /// <summary>
    /// The Types in variable form
    /// </summary>
    public Type type;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;

        life = life + Time.deltaTime;

        if (life >= 4)
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// If the health power up is collided with do this
    /// </summary>
    public void Health()
    {

    }
    /// <summary>
    /// If a "negative" power up is hit, do this
    /// </summary>
    public void Negative()
    {

    }

}
