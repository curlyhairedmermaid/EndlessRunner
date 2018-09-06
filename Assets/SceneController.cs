using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public GameObject prefabWall;
    public GameObject prefabSpeedUp;
    float delayUntilSpawn = 0;
    float delayUntilSpawn2 = 0;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        delayUntilSpawn -= Time.deltaTime;
        if (delayUntilSpawn <= 0)
        {
            Vector3 pos = new Vector3(0, 0, 20);
            Instantiate(prefabWall, pos, Quaternion.identity);
            delayUntilSpawn = Random.Range(1, 3);

            Vector3 pos2 = new Vector3(0, 0, 20);
            Instantiate(prefabSpeedUp, pos2, Quaternion.identity);
            delayUntilSpawn2 = Random.Range(1, 3);
        }
	}
}
