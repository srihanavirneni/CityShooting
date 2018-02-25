using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameUI : MonoBehaviour {

    public Image fadeOut;
    public GameObject GameOverUI;

    private void Start()
    {
        FindObjectOfType<Player>().OnDeath += OnGameOver;
    }

    void OnGameOver()
    {
        StartCoroutine(Fade(Color.clear, Color.white, 1));
        GameOverUI.SetActive(true);
    }

    IEnumerator Fade(Color from, Color to, float time)
    {
        float speed = 1 / time;
        float percent = 0;

        while (percent < 1) 
        {
            percent += Time.deltaTime * speed;
            fadeOut.color = Color.Lerp(from, to, percent);
            yield return null;
        }
    }

    // This is our UI input that we can use to make the play again button interactable.
    public void StartNewGame()
    {
        SceneManager.LoadSceneAsync("Level01");
    }

	
}