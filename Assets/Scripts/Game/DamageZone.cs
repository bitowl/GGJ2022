using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{

    private List<DamageComponent> damageReceivers = new List<DamageComponent>();
    public float damagePerSecond = 10;

    void OnTriggerEnter(Collider collider)
    {
        var damage = collider.GetComponentInParent<DamageComponent>();
        if (damage != null && !damageReceivers.Contains(damage))
        {
            damageReceivers.Add(damage);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        var damage = collider.GetComponentInParent<DamageComponent>();
        if (damage != null && damageReceivers.Contains(damage))
        {
            damageReceivers.Remove(damage);
        }
    }

    void Update()
    {
        foreach (var receivers in damageReceivers)
        {
            Debug.Log("DAAMAGE");
            receivers.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }
}
