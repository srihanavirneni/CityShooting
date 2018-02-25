using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu"); 
    }

    public void Tutorial()
    {
        SceneManager.LoadSceneAsync("Tutorial");
    }

    public void Credtis()
    {
        SceneManager.LoadSceneAsync("Credits");
    }

}
