using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    /// <summary>
    /// The starting point of the object
    /// </summary>
    public Transform pointIn;
    /// <summary>
    /// The ending point of the object
    /// </summary>
    public Transform pointOut;
    /// <summary>
    /// the array holding the different possible spawn points of walls on the track
    /// </summary>
    public Transform[] wallSpawnPoints;
    /// <summary>
    /// Reference to the wall prefab
    /// </summary>
    public GameObject prefabWall;
    /// <summary>
    /// The Refence to the short wall
    /// </summary>
    public GameObject prefabWallLow;
    /// <summary>
    /// Reference to the wall with the gap in the middle of it
    /// </summary>
    public GameObject prefabWallMid;
    /// <summary>
    /// Reference to the health powerup
    /// </summary>
    public GameObject prefabHealth;
    public GameObject prefabRot;
    /// <summary>
    /// the speed of the track
    /// </summary>
    public float speed = 10;
    /// <summary>
    /// Is dead variable. Hidden in the inspector
    /// </summary>
    [HideInInspector] public bool isDead = false;
    /// <summary>
    /// Calls when instantiated
    /// </summary>
    void Start()
    {
        if (wallSpawnPoints.Length == 0) return;
        if (!prefabWall) return;

        // Get a random position:
        int randIndex = Random.Range(0, wallSpawnPoints.Length);
        Vector3 spawnPos = wallSpawnPoints[randIndex].position;

        int randIndex2 = Random.Range(0, wallSpawnPoints.Length);
        Vector3 spawnPos2 = wallSpawnPoints[randIndex2].position;


        // Spawn a wall, parent it to this chunk of track:
        Instantiate(WhichWall(), spawnPos, Quaternion.identity, transform);

        if (spawnPos2 != spawnPos) Instantiate(prefabHealth, spawnPos2, Quaternion.identity, transform);



    }
    /// <summary>
    /// Sets the speed of the objects and the position that triggers their death
    /// </summary>
    void Update()
    {
        transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;

        if (pointOut.position.z < -30)
        {
            isDead = true;
        }
    }
    /// <summary>
    /// Chooses which wall prefab will be spawned
    /// </summary>
    /// <returns>Which wall prefab has been selected</returns>
    GameObject WhichWall()
    {
        int which = Random.Range(1, 3);
        if (which == 1)
        {
            return prefabWall;
        }
        else if (which == 2)
        {
            return prefabWallLow;
        }
        else if (which == 3)
        {
            return prefabWallMid;
        }
        else
        {
            return prefabWall;
        }
    }



}
