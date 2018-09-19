using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

   // public AudioSource blipSound;
public void PlayButtonPressed()
    {
        print("PLAY");
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void OptionsButtonPressed()
    {
        //blipSound.Play();
        print("What u want");
    }
    public void QuitButtonPressed()
    {
        print("No");
        Application.Quit();
    }
}
