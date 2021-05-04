using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText, power;
    public Coroutine pow;

    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        power.text = "";
    }

    public void ScoreUpdate()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void count()
    {
        if(pow != null)
        {
            StopCoroutine(pow);
        }
        pow = StartCoroutine(down());
    }

    IEnumerator down()
    {
        int count = 6;
        while (count > 0)
        {
            power.text = "Power: " + count + "s";
            count--;
            yield return new WaitForSeconds(1);
        }
        power.text = "";
    }
}
