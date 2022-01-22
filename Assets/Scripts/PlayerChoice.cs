using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Game/Player Choice")]
public class PlayerChoice : ScriptableObject
{
    public string controlScheme;

    [Required]
    public CharacterData character;

    public InputDevice _inputDevice;
    public enum Device
    {
        None,
        CurrentKeyboard,
        CurrentController
    };
    public Device fallbackDevice;

    public InputDevice inputDevice
    {
        get
        {
            if (_inputDevice != null)
            {
                return _inputDevice;
            }
            switch (fallbackDevice)
            {
                case Device.CurrentKeyboard:
                    return Keyboard.current;
                case Device.CurrentController:
                    return Gamepad.current;
                case Device.None:
                default:
                    Debug.LogError("No input device configured for player.");
                    // for now assume keyboard
                    return Keyboard.current;
                    // TODO return null;

            }

        }
    }
}
