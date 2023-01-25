using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;

    public InputManager inputManager;

    private void Update()
    {
        if (gameEnded)
        {
            return;
        }


        if (PlayerStat.health <= 0)
        {
            EndGame();
        }

    }

    public void EndGame()
    {
        gameEnded = true;
        SceneManager.LoadScene("GameOver");
        inputManager.PlayerCursorIsLocked = false;
        
    }
}
