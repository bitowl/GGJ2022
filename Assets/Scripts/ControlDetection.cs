using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlDetection : MonoBehaviour
{
    public PlayerChoice p1Choice;
    public PlayerChoice p2Choice;

    public string controlSchemeWASD;
    public List<string> wasdInputs;
    public string controlSchemeArrow;
    public List<string> arrowInputs;
    public string controlSchemeGamepad;

    public GameMenu gameMenu;

    private PlayerControls playerControls;

    void Awake()
    {
        playerControls = new PlayerControls();
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        playerControls.Player.Movement.performed += OnMove;
        playerControls.Player.Jump.performed += OnJump;

        // Player choices have not yet been confirmed
        p1Choice.confirmed = false;
        p2Choice.confirmed = false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movementInput = context.ReadValue<Vector2>();
        bool joinLeft = false;
        bool joinRight = false;
        if (movementInput.x < -0.5f)
        {
            // Try to join left
            joinLeft = true;
        }
        else if (movementInput.x > 0.5f)
        {
            // Try to join right
            joinRight = true;
        }

        if (!(joinLeft || joinRight))
        {
            // not joining anything
            return;
        }

        // Detect device and control scheme
        InputDevice inputDevice = context.control.device;
        string controlScheme = null;

        Debug.Log(inputDevice.name);
        if (inputDevice == Keyboard.current)
        { // TODO assuming one keyboard
            Debug.Log(context.control.path);
            if (wasdInputs.Contains(context.control.path))
            {
                controlScheme = controlSchemeWASD;
            }
            else if (arrowInputs.Contains(context.control.path))
            {
                controlScheme = controlSchemeArrow;
            }
            else
            {
                Debug.LogError($"Could not detect controlScheme for {context.control.path}!");
                return;
            }
        }
        else
        {
            // Assuming gamepad
            controlScheme = controlSchemeGamepad;
        }


        if (joinLeft)
        {
            if (p1Choice.inputDevice == inputDevice && p1Choice.controlScheme == controlScheme)
            {
                // Already joined
            }
            else if (p2Choice.inputDevice == inputDevice && p2Choice.controlScheme == controlScheme)
            {
                // We switch
                p2Choice.inputDevice = p1Choice.inputDevice;
                p2Choice.controlScheme = p1Choice.controlScheme;
                p2Choice.confirmed = false;
                p1Choice.inputDevice = inputDevice;
                p1Choice.controlScheme = controlScheme;
                p1Choice.confirmed = false;
            }
            else
            {
                // New join
                p1Choice.inputDevice = inputDevice;
                p1Choice.controlScheme = controlScheme;
                p1Choice.confirmed = false;
            }

        }
        else if (joinRight)
        {
            if (p2Choice.inputDevice == inputDevice && p2Choice.controlScheme == controlScheme)
            {
                // Already joined
            }
            else if (p1Choice.inputDevice == inputDevice && p1Choice.controlScheme == controlScheme)
            {
                // We switch
                p1Choice.inputDevice = p2Choice.inputDevice;
                p1Choice.controlScheme = p2Choice.controlScheme;
                p1Choice.confirmed = false;
                p2Choice.inputDevice = inputDevice;
                p2Choice.controlScheme = controlScheme;
                p2Choice.confirmed = false;
            }
            else
            {
                // New join
                p2Choice.inputDevice = inputDevice;
                p2Choice.controlScheme = controlScheme;
                p2Choice.confirmed = false;
            }
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log("Jump" + context.control.path + " " + context.control.device);

        // TODO deduplicate 
        // Detect device and control scheme
        InputDevice inputDevice = context.control.device;
        string controlScheme = null;

        if (inputDevice == Keyboard.current)
        { // TODO assuming one keyboard
            Debug.Log(context.control.path);
            if (wasdInputs.Contains(context.control.path))
            {
                controlScheme = controlSchemeWASD;
            }
            else if (arrowInputs.Contains(context.control.path))
            {
                controlScheme = controlSchemeArrow;
            }
            else
            {
                Debug.LogError($"Could not detect controlScheme for {context.control.path}!");
                return;
            }
        }
        else
        {
            // Assuming gamepad
            controlScheme = controlSchemeGamepad;
        }


        if (p1Choice.inputDevice == inputDevice && p1Choice.controlScheme == controlScheme)
        {
            p1Choice.confirmed = !p1Choice.confirmed;
        }
        else if (p2Choice.inputDevice == inputDevice && p2Choice.controlScheme == controlScheme)
        {
            p2Choice.confirmed = !p2Choice.confirmed;
        }

        if (p1Choice.confirmed && p2Choice.confirmed)
        {
            // TODO maybe add a small timer in which they can still revert their decision
            gameMenu.ShowCharacterMenu();
            p1Choice.confirmed = false;
            p2Choice.confirmed = false;
        }
    }


}
