using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour {
    /// <summary>
    /// The noise that plays when a button is hit
    /// </summary>
   public AudioSource blipSound;
    /// <summary>
    /// the music playing in the main menu
    /// </summary>
    public AudioSource music;
    private void Start()
    {
        music.Play();
    }
    /// <summary>
    /// what happens when the play button is pressed
    /// </summary>
    public void PlayButtonPressed()
    {
        blipSound.Play();
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    /// <summary>
    /// What happens with the options button is pressed
    /// </summary>
    public void OptionsButtonPressed()
    {
        blipSound.Play();
        print("What u want");
    }
    /// <summary>
    /// What happens when the quit button is pressed
    /// </summary>
    public void QuitButtonPressed()
    {
        blipSound.Play();
        print("No");
        Application.Quit();
    }
}
