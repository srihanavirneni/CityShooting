﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public void EndGame()
    {
        StartCoroutine(PlayEndGameAnimation());
    }

    IEnumerator PlayEndGameAnimation()
    {
        Debug.Log("GameOver");
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
