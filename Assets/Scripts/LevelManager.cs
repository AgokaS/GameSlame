using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Start()
    {
        
    }

    public void Clik_play()
    {
        Next();
    }

    public void Clik_restart()
    {
        Restart();
    }

    public static void Next()
    {
        if (SceneManager.GetActiveScene().buildIndex+1 < SceneManager.sceneCountInBuildSettings)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
        {
            Application.Quit();
        }
    }

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
