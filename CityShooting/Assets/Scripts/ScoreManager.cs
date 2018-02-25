using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int count;

    public static Text scoreText;

    private void Start()
    {
        count = 0;
        scoreText = GetComponent<Text>();

    }

    public static void SetCount(int count)
    {
        scoreText.text = count.ToString();
    }
}
