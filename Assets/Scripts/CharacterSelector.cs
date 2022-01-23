using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSelector : MonoBehaviour
{
    public CharacterSelection selection;

    private bool down;

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movementInput = context.ReadValue<Vector2>();
        if (movementInput.x < -0.5f)
        {
            if (!down)
            {
                selection.SelectPrevious();

            }
            down = true;
        }
        else if (movementInput.x > 0.5f)
        {
            if (!down)
            {
                selection.SelectNext();
            }
            down = true;
        }
        else
        {
            down = false;
        }


    }
}
