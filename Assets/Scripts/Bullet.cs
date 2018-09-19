using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject prefabBullet;
    float velocity= .5f;
    float life = 0;
    int count = 0;
    
    // Use this for initialization
    void Start()
    {
       
    }
    
    // Update is called once per frame
    public void Update()
    {
        print(transform.position);
        if(count < 5)
        {
            print("wju");
            if (Input.GetKeyDown("left shift"))
            {
               
                Instantiate(prefabBullet);
                transform.position += new Vector3(0, 0, velocity);
                count += 1;
            }
        }
        if (life <= 5)
        {
            transform.position += new Vector3(0, 0, velocity);
            life += Time.deltaTime;

        }
        else
        {
            Destroy(gameObject);
            count -= 1;
        }

    }
    
}