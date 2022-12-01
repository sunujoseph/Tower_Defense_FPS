using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewPauseMenu : MonoBehaviour
{

    private PauseMenu playerControls;
    private InputAction menu;

    [SerializeField]
    public InputManager inputManagerPlayer;


    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject crosshair;
    [SerializeField] private bool isPaused;

    // Start is called before the first frame update
    void Awake()
    {
        playerControls = new PauseMenu();

        //Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (inputManagerPlayer.usingTurretNode == false)
        {
            inputManagerPlayer.MenuFunction();
        }
               
    }

private void OnEnable()
    {
        menu = playerControls.Menu.Escape;
        menu.Enable();

        menu.performed += Pause;
    }

    private void OnDisable()
    {
        menu.Disable();
    }

    void Pause(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
        Time.timeScale = 0.0f;
        AudioListener.pause = true;
        pauseUI.SetActive(true);
        crosshair.SetActive(false);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
        pauseUI.SetActive(false);
        crosshair.SetActive(true);
        isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
