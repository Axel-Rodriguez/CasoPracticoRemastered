using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
    public void play()
    {
        SceneManager.LoadScene(1);
    }
    public void instructions()
    {
        SceneManager.LoadScene(2);
    }
    public void gameOver()
    {
        SceneManager.LoadScene(3);
    }

    public void exit()
    {
        Application.Quit();
        Debug.Log("Game is exiting. Only in built application.");
    }
}
