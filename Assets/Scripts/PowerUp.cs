using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
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
        Health,
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

}
