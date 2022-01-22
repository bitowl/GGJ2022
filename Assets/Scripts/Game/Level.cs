using UnityEngine;

public class Level : MonoBehaviour
{
    [Tooltip("Places where players can spawn")]
    public Transform[] spawnPoints;

    public PlayerManager playerManager;

    void Awake()
    {
        if (spawnPoints.Length != 2)
        {
            Debug.LogError("Exactly two spawn points have to be defined in the Level component on the GameManagers object!");
            return;
        }
        //playerManager.playerConfigs[0].spawnPoint = spawnPoints[0];
        //playerManager.playerConfigs[1].spawnPoint = spawnPoints[1];
    }
}
