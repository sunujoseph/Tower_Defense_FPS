using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : Interactable
{

    public GameObject towerMenu;

    public static bool isTower = false;

    // Start is called before the first frame update
    void Start()
    {
        towerMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTower)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                towerMenu.gameObject.SetActive(false);
                Time.timeScale = 1.0f;
                isTower = false;
            }
        }
    }

    protected override void Interact()
    {
        base.Interact();
    }

    public void Tower()
    {
        OpenTower();
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            towerMenu.gameObject.SetActive(false);
            Time.timeScale = 1.0f;
            isTower = false;
        }
    }

    public void OpenTower()
    {
        towerMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;

        isTower = true;
    }

    public void CloseTower()
    {
        Debug.Log("WOKRING");
        towerMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
