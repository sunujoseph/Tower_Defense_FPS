using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false; 

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

    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over");
    }
}
