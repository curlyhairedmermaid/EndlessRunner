using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {
    /// <summary>
    /// a list of AABB objects
    /// </summary>
    static List<AABB> aabbs = new List<AABB>();
    /// <summary>
    /// Adds objects to the AABB list
    /// </summary>
    /// <param name="obj">The object being added</param>
    static public void Add(AABB obj)
    {
        aabbs.Add(obj);
        //print("there are " + aabbs.Count + " AABBs registered");
    }
    /// <summary>
    /// Removes objects from the AABB List
    /// </summary>
    /// <param name="obj">The object being removed</param>
    static public void Remove(AABB obj)
    {
        aabbs.Remove(obj);
    }


	// Use this for initialization
	void Start () {
		
	}

    /// <summary>
    /// Late update is called after update
    /// </summary>
    // Update is called once per frame
    void LateUpdate () {

		foreach(AABB a in aabbs)
        {
            foreach(AABB b in aabbs)
            {
                if (a == b) continue;
                if (a.isDoneChecking || b.isDoneChecking) continue;

                if (a.CheckOverlap(b))
                {
                    // overlapping!!
                    a.BroadcastMessage("OverlappingAABB", b); // observer design pattern
                    b.BroadcastMessage("OverlappingAABB", a);
                }

            }
            a.isDoneChecking = true;
        }


	}
}
