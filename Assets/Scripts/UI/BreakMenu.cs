using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class BreakMenu : MonoBehaviour
{
    public GameObject canvas;
    public InputAction escapeButton;

    void OnEnable()
    {
        escapeButton.Enable();
    }

    void OnDisable()
    {
        escapeButton.Disable();
    }

    public void HideMenu()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
    }

    public void ShowMenu()
    {
        Time.timeScale = 0;
        canvas.SetActive(true);
    }

    void Update()
    {
        if (escapeButton.triggered)
        {
            if (canvas.activeInHierarchy)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
        }
    }
}
