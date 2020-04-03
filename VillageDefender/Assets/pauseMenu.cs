using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public bool GameIsPause = false;
    public GameObject pauseMenuiUI;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
     }

    // Update is called once per frame
    public void Resume()
    {
        pauseMenuiUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
    public void Pause()
    {
        pauseMenuiUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
}
