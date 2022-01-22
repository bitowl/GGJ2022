using NaughtyAttributes;
using UnityEngine;

public enum Team
{
    Veggies,
    Meat
};

/// <summary>
/// Data that defines a character
/// </summary>
[CreateAssetMenu(menuName = "Game/Character Data")]
public class CharacterData : ScriptableObject
{
    public float health = 100;
    public float damageMultiplier = 1;
    [Required]
    public GameObject modelPrefab;
    public Team team;
}
