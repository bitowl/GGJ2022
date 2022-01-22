using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Player))]
public class DamageComponent : MonoBehaviour
{
    private PlayerData playerData;
    private Rigidbody rb;
    private Vector3 cachedVelocity;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        playerData = GetComponent<Player>().playerData;
        if (!playerData)
        {
            Debug.LogWarning("Damage component does not work here. (Players are probably not spawned by PlayerManager)");
            Destroy(this);
            return;
        }
        //Debug.Log("get player data " + playerData);
        playerData.maxHealth = playerData.character.health;
        playerData.currentHealth = playerData.character.health;
    }



    void FixedUpdate()
    {
        // Need to cache the velocity, because OnCollionEnter already has the velocities after the collision
        cachedVelocity = rb.velocity;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player otherPlayer = collision.gameObject.GetComponent<Player>();
            DamageComponent otherDamage = otherPlayer.GetComponent<DamageComponent>();

            // Damage the other player according to our velocity. The other player will damage us according to their velocity in their collision method.
            float myVelocity = cachedVelocity.magnitude;
            float damage = myVelocity * playerData.character.damageMultiplier;
            Debug.Log($"Deal {damage} damage {rb.name} {rb.velocity.magnitude}");
            otherDamage.TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        playerData.currentHealth -= damage;

        if(playerData.currentHealth <= 0)
        {
            Reload();
        }
    }

    public void Reload()
    {
        SceneManager.LoadScene("GameOver");
    }
}
