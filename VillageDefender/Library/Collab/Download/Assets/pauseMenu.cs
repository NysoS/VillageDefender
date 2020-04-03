using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenuiUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPause)
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
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    GameIsPause = false;
    }
    public void Pause()
    {
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    GameIsPause = true;
    }
}
