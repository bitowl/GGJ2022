using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupGameObject;
    [Tooltip("Time until it respawns in seconds")]
    public float respawnTime = 10;
    private float nextRespawn = 0;

    void Update()
    {
        if (nextRespawn > 0)
        {
            nextRespawn -= Time.deltaTime;
            if (nextRespawn <= 0)
            {
                // Respawn
                pickupGameObject.SetActive(true);
                nextRespawn = 0;
            }
        }
        else if (!pickupGameObject.activeInHierarchy)
        {
            nextRespawn = respawnTime;
        }
    }
}
