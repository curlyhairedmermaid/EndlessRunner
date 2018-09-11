using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    // Use this for initialization
    public Transform viewTarget;

    void Start()
    {
    }

    void LateUpdate()
    {


        if (viewTarget)
        {
            //easing
            //transform.position = viewTarget.position;

            transform.position += new Vector3((viewTarget.position.x - transform.position.x) * .1f, 0, 0);
            //transform.position = Vector3.Lerp(transform.position, viewTarget.position, (Time.deltaTime * 10));
        }
    }
}
