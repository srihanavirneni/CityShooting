using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button[] levelButtons;

	public void Play()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Extra stuff for game over
    public void GoBackToMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

	public void GoBackToLevelSelection()
	{
		SceneManager.LoadSceneAsync("LevelSelection");
	}

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
    }

}
