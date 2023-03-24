using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool newGame;

    [SerializeField] GameObject controlsMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject optionsText;

    private void Start()
    {
        controlsMenu.SetActive(false);
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PlayMenu");
        newGame = true;
        Cursor.visible = true;
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

    public void MainGame()
    {
        SceneManager.LoadScene("Khang's Version");
        Cursor.visible = false;
    }

    //essentially so that a seperate canvas will pop up on a specific button click -> for cooler UI
    public void ActiveControls() // prob an easier way to do this but good enough for now
    {
        controlsMenu.SetActive(true);
        optionsText.SetActive(false);
    }

    public void DeactiveControls()
    {
        controlsMenu.SetActive(false);
        optionsText.SetActive(true);
    }

    public void ActiveSettings()
    {
        settingsMenu.SetActive(true);
        optionsText.SetActive(false);
    }

    public void DeactiveSettings()
    {
        settingsMenu.SetActive(false);
        optionsText.SetActive(true);
    }
}

