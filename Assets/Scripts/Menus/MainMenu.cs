using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool newGame;

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
        newGame = true;
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial"); // will update this later
    }

    // function to close the game
    public void QuitGame()
    {
        // to show it works without needing to build
        Debug.Log("Exiting Game...");
        Application.Quit();
    }
}

