using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroPickup : MonoBehaviour
{
    public float nitroSeconds = 2;

    void OnTriggerEnter(Collider collider)
    {
        var player = collider.GetComponentInParent<Player>();
        if (player != null)
        {
            player.AddNitro(nitroSeconds);
            gameObject.SetActive(false);
        }
    }
}
