using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerChoiceDisplay : MonoBehaviour
{
    public PlayerChoice playerChoice;
    public TextMeshProUGUI joinText;
    public TextMeshProUGUI confirmText;
    public string joinTextEmpty;

    void Start()
    {

    }

    void Update()
    {
        joinText.SetText(playerChoice.controlScheme == "" ? joinTextEmpty : playerChoice.controlScheme);
        confirmText.SetText(playerChoice.confirmed ? "Ready to Start!" : "Press Jump to confirm");
    }
}
