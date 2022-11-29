using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;

    public bool PlayerCursorIsLocked;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        PlayerCursorIsLocked = true;

        onFoot.Jump.performed += ctx => motor.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());

        if (PlayerCursorIsLocked == true)
        {
            motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        }
        else
        {
            // no movement while in menus
        }
    }

    void LateUpdate()
    {
        //look.ProcessLook(onFoot.Look.ReadValue<Vector2>());

        if (PlayerCursorIsLocked == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            //look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
        }
    }

    public void SetMouseLock(bool mlock)
    {
        PlayerCursorIsLocked = mlock;
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
