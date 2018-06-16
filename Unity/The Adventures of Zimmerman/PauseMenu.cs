using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;

    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            //sets to opposite of current pause state
            paused = !paused;
        }
        if (paused)
        {
            PauseUI.SetActive(true);
            //sets game time to zero
            Time.timeScale = 0;
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            // resume game time
            Time.timeScale = 1;
        }
    }
    public void ResumeGame()
    {
        paused = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Map1");
    }

    public void ExitGame()
    {
        //quit to start menu
        SceneManager.LoadScene("StartMenu");
    }

}
