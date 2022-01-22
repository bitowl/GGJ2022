using UnityEngine;

public class MockPlayer : MonoBehaviour
{
    public PlayerData playerData;
    public float initialHealth = 100;

    void Start()
    {
        playerData.maxHealth = initialHealth;
        playerData.currentHealth = initialHealth;
    }
}
