using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        finalScore();
    }

    public void finalScore()
    {
        scoreText.text = "Final score: " + PlayerPrefs.GetInt("score");
    }
}
