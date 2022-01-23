using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerChoices : MonoBehaviour
{
    public PlayerChoice p1Choice;
    public PlayerChoice p2Choice;
    public CharacterData p1Character;
    public CharacterData p2Character;

    void OnEnable()
    {
        Debug.Log("Resetting " + p1Choice.character + " / " + p1Character);
        p1Choice.controlScheme = "";
        p1Choice.character = p1Character;
        p1Choice.confirmed = false;
        p2Choice.controlScheme = "";
        p2Choice.character = p2Character;
        p2Choice.confirmed = false;
        Debug.Log("Done " + p1Choice.character + " / " + p1Character);
    }
}
