using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Game/Menu State")]
public class MenuState : ScriptableObject
{
    public enum State
    {
        Main,
        PlayerSelection,
        CharacterSelection
    }
    public State state;
}
