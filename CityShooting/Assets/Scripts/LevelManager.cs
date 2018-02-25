using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public string nextLevel = "Level02";
    public int levelToReach = 2;

    public void WinLevel()
    {
        Debug.Log("You won");
        PlayerPrefs.SetInt("levelReached", levelToReach);
        SceneManager.LoadSceneAsync(nextLevel);
    }

}
