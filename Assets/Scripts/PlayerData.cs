using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Player Data")]
public class PlayerData : ScriptableObject
{
    [InfoBox("Stores runtime data for the players")]
    public int id;
    [ReadOnly]
    public CharacterData character;
    [ReadOnly]
    public float currentHealth;
    [ReadOnly]
    public float maxHealth;
    [ReadOnly]
    public Character charComponent;
    [ReadOnly]
    public float currentNitro;
    [ReadOnly]
    public float maxNitro;
}
