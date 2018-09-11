using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    public int health = 3;
    float speed = -10;
    public float laneWidth = 2;
    int lane = 0;
    float life = 0;
    public enum Type // Powerup.Type
    {
        None,
        Slowmo,
        Health,
        JetpackBoost,
        Negative
    }
    
    public Type type;
    void Start()
    {
        lane = Random.Range(-2, 2);
        float targetX = lane * laneWidth;
        float x = (targetX - transform.position.x);
        transform.position += new Vector3(x, 0, 0);
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
    public void Slow()
    {
       
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
