using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Player Choice")]
public class PlayerChoice : ScriptableObject
{
    public string controlScheme;

    [Required]
    public CharacterData character;
}
