using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class WinnerText : MonoBehaviour
{
    public BoolVar p1Won;

    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = p1Won.value ? "You beat the meat!" : "The meat has beaten you!";
    }
}
