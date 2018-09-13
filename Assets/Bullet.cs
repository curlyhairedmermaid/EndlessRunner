using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class Bullet : MonoBehaviour
{/*
    public GameObject prefabBullet;
    Vector3 velocity;
    List<Bullet> bullets = new List<Bullet>();
    float life = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (life <= 5)
        {
            velocity += new Vector3(0, 0, 25);
            transform.position += (velocity * Time.deltaTime);
            life += Time.deltaTime;
        }
        else
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                {
                    Destroy(bullets[i].gameObject);
                    bullets.RemoveAt(i);
                }
            }
        }
        while (bullets.Count < 5)
            if (Input.GetKeyDown("left shift"))
            {
                Instantiate(prefabBullet);
                print(transform.position);
            }

    }

}*/