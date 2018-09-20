using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{    /// <summary>
     /// the music playing in the main menu
     /// </summary>
    public AudioSource music;
    /// <summary>
    /// The array holding our tracks
    /// </summary>
    public Track[] prefabTracks;
    /// <summary>
    /// Our current score
    /// </summary>
    public int score = 0;
    /// <summary>
    /// Our list of tracks
    /// </summary>
    List<Track> tracks = new List<Track>();
    /// <summary>
    /// Our text object being rendered to the screen
    /// </summary>
    public Text scored;

    /// <summary>
    /// the rotation speed of the screen
    /// </summary>
    public float rotSpeed = .18f;


    void Start()
    {
        SpawnSomeTrack();
        music.Play();
    }
    /// <summary>
    /// our update method
    /// </summary>
	void Update()
    {
        for (int i = tracks.Count - 1; i >= 0; i--)
        {
            if (tracks[i].isDead)
            {
                Destroy(tracks[i].gameObject);
                tracks.RemoveAt(i);
                score++;
            }
        }

        if (tracks.Count < 5) SpawnSomeTrack();

        transform.Rotate(0, 0, rotSpeed);
    }
    /// <summary>
    /// spawns track at the end of the previous one
    /// </summary>
    void SpawnSomeTrack()
    {
        scored.text = "Score: " + score.ToString();
        while (tracks.Count < 5)
        {

            Vector3 ptOut = Vector3.zero;
            if (tracks.Count > 0) ptOut = tracks[tracks.Count - 1].pointOut.position;


            Track prefab = prefabTracks[Random.Range(0, prefabTracks.Length)]; // random prefab!!!1


            Vector3 ptIn = prefab.pointIn.position;
            Vector3 pos = (prefab.transform.position - ptIn) + ptOut;

            Track newTrack = Instantiate(prefab, pos, Quaternion.identity);
            tracks.Add(newTrack);
        }
    }
}
