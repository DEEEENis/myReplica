using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject Win;
    public GameObject Restart;
    public GameObject PauseScreen;
    
    
    public void Play()
    {
        if (GAME.LevelIndex <= 4)
        {
            SceneManager.LoadScene(GAME.LevelIndex);
            Time.timeScale = 1f;
        }
        else
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
        }
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Next()
    {
        Win.SetActive(false);
        Time.timeScale = 1f;
        if (GAME.LevelIndex < 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restar()
    {
        Restart.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pause()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
