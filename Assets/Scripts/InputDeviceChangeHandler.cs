using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.LowLevel;
using System;

// add this into built-in button you can create from menu: UI/Button
public class InputDeviceChangeHandler : MonoBehaviour
{
    // refs to Button's components
    private Image buttonImage;

    // refs to your sprites
    public Sprite gamepadImage;
    public Sprite keyboardImage;

    void Awake()
    {
        buttonImage = GetComponent<Image>();
        PlayerInput input = FindObjectOfType<PlayerInput>();
        //updateButtonImage(input.currentControlScheme);
    }

    void OnEnable()
    {
        //InputUser.listenForUnpairedDeviceActivity = 1;
        InputUser.onChange += onInputDeviceChange;
        InputUser.onUnpairedDeviceUsed += onUnpairedDeviceUsed;

    }

    private void onUnpairedDeviceUsed(InputControl control, InputEventPtr eventPtr)
    {
        Debug.Log(control);
    }

    void OnDisable()
    {
        InputUser.listenForUnpairedDeviceActivity = 0;
        InputUser.onChange -= onInputDeviceChange;
        InputUser.onUnpairedDeviceUsed -= onUnpairedDeviceUsed;
    }

    void onInputDeviceChange(InputUser user, InputUserChange change, InputDevice device)
    {
        if (change == InputUserChange.ControlSchemeChanged)
        {
            Debug.Log(change);
            //            updateButtonImage(user.controlScheme.Value.name);
        }
    }

    void updateButtonImage(string schemeName)
    {
        // assuming you have only 2 schemes: keyboard and gamepad
        if (schemeName.Equals("Gamepad"))
        {
            buttonImage.sprite = gamepadImage;
        }
        else
        {
            buttonImage.sprite = keyboardImage;
        }
    }
}