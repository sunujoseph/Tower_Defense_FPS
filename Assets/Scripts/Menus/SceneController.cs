using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Closing Game..."); // to show functionality in editor
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Khang's Version");
    }
}
