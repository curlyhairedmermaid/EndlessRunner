using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    /// <summary>
    /// The transform to the target
    /// </summary>
    public Transform viewTarget;
    // Use this for initialization
    void Start()
    {
    }
    /// <summary>
    /// Late update is called after update
    /// </summary>
    // Update is called once per frame
    void LateUpdate()
    {


        if (viewTarget)
        {
            //easing
            transform.position += new Vector3((viewTarget.position.x - transform.position.x) * .1f, 0, 0);
        }
    }
}
