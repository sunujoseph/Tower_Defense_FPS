using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewPauseMenu : MonoBehaviour
{

    private PauseMenu playerControls;
    private InputAction menu;

    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject crosshair;
    [SerializeField] GameObject inputManagement;
    [SerializeField] private bool isPaused;

    InputManager inputManager;


    // Start is called before the first frame update
    void Awake()
    {
        playerControls = new PauseMenu();
       
    }

    void Start()
    {
        inputManager.PlayerCursorIsLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
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

        inputManager.PlayerCursorIsLocked = false;
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
        pauseUI.SetActive(false);
        crosshair.SetActive(true);
        isPaused = false;

        inputManager.PlayerCursorIsLocked = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
