using UnityEngine;

[RequireComponent(typeof(Player))]
public class DamageComponent : MonoBehaviour
{
    private PlayerData playerData;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        playerData = GetComponent<Player>().playerData;
        Debug.Log("get player data " + playerData);
        playerData.maxHealth = playerData.character.health;
        playerData.currentHealth = playerData.character.health;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player otherPlayer = collision.gameObject.GetComponent<Player>();
            DamageComponent otherDamage = otherPlayer.GetComponent<DamageComponent>();

            // Damage the other player according to our velocity. The other player will damage us according to their velocity in their collision method.
            float myVelocity = rb.velocity.magnitude;
            float damage = myVelocity * playerData.character.damageMultiplier;
            otherDamage.TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        playerData.currentHealth -= damage;
    }
}
