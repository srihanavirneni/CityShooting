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

	public void StartNewGame2()
	{
		SceneManager.LoadSceneAsync("Level02");
	}

	public void StartNewGame3()
	{
		SceneManager.LoadSceneAsync("Level03");
	}

	public void StartNewGame4()
	{
		SceneManager.LoadSceneAsync("Level04");
	}

	public void StartNewGame5()
	{
		SceneManager.LoadSceneAsync("Level05");
	}

	public void StartNewGame6()
	{
		SceneManager.LoadSceneAsync("Level06");
	}

	public void StartNewGame7()
	{
		SceneManager.LoadSceneAsync("Level07");
	}

	public void StartNewGame8()
	{
		SceneManager.LoadSceneAsync("Level08");
	}

	public void StartNewGame9()
	{
		SceneManager.LoadSceneAsync("Level09");
	}

    public void StartNewGame10()
    {
        SceneManager.LoadSceneAsync("Level10");
    }

}