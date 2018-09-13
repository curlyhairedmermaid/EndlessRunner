using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject prefabBullet;
    Vector3 velocity;
    float life = 0;
    int count = 0;

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
            Destroy(gameObject);
        }
        while (count < 5)
        {
            if (Input.GetKeyDown("left shift"))
            {
                Instantiate(prefabBullet);
                print(transform.position);
                count += 1;
            }
        }
    }

}