using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    // to begin the game
	public void StartGame()
    {
        // to get next scene in index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // to load scene named "Map1"
        // SceneManager.LoadScene("Map1");
    }
    // tomquit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
