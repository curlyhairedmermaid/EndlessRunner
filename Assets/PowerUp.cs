using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
    public int health = 3;
    public enum Type // Powerup.Type
    {
        None,
        Slowmo,
        Health,
        JetpackBoost,
        Negative
    }

    public Type type;

    public void Slow()
    {
        ObstacleMovement obstacle = GetComponent<ObstacleMovement>();
        obstacle.SlowDown();
    }
    public void Health()
    {
        if (health < 5)
        {
            health++;
            print(health);
        }
    }
    public void Jetpack()
    {

    }
    public void Negative()
    {
        if (health > 1)
        {
            health--;
            print(health);
        }
        else
        {
            //die
        }
    }

}
