using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float health = 40;

    void OnTriggerEnter(Collider collider)
    {
        var damage = collider.GetComponentInParent<DamageComponent>();
        if (damage != null)
        {
            damage.TakeDamage(-health);
            gameObject.SetActive(false);
        }
    }
}
