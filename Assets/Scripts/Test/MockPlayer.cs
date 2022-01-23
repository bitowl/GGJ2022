using UnityEngine;

public class MockPlayer : MonoBehaviour
{
    public PlayerData playerData;
    public float initialHealth = 100;
    public float initialNitro = 5;

    void Start()
    {
        playerData.maxHealth = initialHealth;
        playerData.currentHealth = initialHealth;
        playerData.maxNitro = initialNitro;
        playerData.currentNitro = initialNitro;
    }
}
