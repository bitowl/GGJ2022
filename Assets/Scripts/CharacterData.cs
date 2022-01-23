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
    public string displayName;
    public float health = 100;
    public float damageMultiplier = 1;
    public float environmentDamageMultiplier = 0.1f;
    [Required]
    public GameObject modelPrefab;
    public Team team;
    public bool hasRotateControls;
    public float maxNitroSeconds = 5;
    public float nitroSpeedMultiplier = 2;
}
