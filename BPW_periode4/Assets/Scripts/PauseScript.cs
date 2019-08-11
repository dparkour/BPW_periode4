using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseScript : MonoBehaviour
{
    GameManager gameManager;
    public KeyCode pauseKey;
    public GameObject PauseMenu;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(pauseKey))
        {
            Pause();
        }
    }

    void Pause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            gameManager.IsPaused = !gameManager.IsPaused;
            PauseMenu.SetActive(!PauseMenu.activeSelf);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            gameManager.IsPaused = !gameManager.IsPaused;
            PauseMenu.SetActive(!PauseMenu.activeSelf);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Continue()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        gameManager.IsPaused = false;
    }

    public void Retry()
    {
        Time.timeScale = 1;
        gameManager.IsPaused = false;
        SceneManager.LoadScene(2);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
