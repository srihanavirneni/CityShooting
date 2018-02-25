using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour {

    public Text gameover;
    public GameObject tapToPlay;
    public GameObject Manager;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "killable")
        {
            gameover.text = "GAME OVER".ToString();
            tapToPlay.SetActive(true);

            Manager.SetActive(false);

        }

        if (col.tag == "win")
        {
            SceneManager.LoadSceneAsync("Win");
        }
    }

    void Start()
    {
        gameover.text = "".ToString();
        tapToPlay.SetActive(false);

        Manager.SetActive(true);
    }


}