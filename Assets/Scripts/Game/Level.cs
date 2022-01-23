using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [Tooltip("Places where players can spawn")]
    public Transform[] spawnPoints;

    public PlayerManager playerManager;

    [Expandable]
    public PlayerChoice[] playerChoices;

    public static Level instance;


    public int scoreToWin = 3;
    public BoolVar p1Won;
    public IntVar p1Score;
    public IntVar p2Score;

    void Awake()
    {
        instance = this;
        if (spawnPoints.Length != 2)
        {
            Debug.LogError("Exactly two spawn points have to be defined in the Level component on the GameManagers object!");
            return;
        }
        //playerManager.playerConfigs[0].spawnPoint = spawnPoints[0];
        //playerManager.playerConfigs[1].spawnPoint = spawnPoints[1];
    }

    public void PlayerDied(int id)
    {
        if (id == 1)
        {
            p2Score.value++;
            if (p2Score.value >= scoreToWin)
            {
                GameOver(false);
                return;
            }
        }
        else
        {
            p1Score.value++;
            if (p1Score.value >= scoreToWin)
            {
                GameOver(true);
                return;
            }
        }
        Reload();
    }

    private void GameOver(bool p1won)
    {
        p1Won.value = p1won;
        p1Score.value = 0;
        p2Score.value = 0;
        SceneManager.LoadScene("GameOver");
    }

    private void Reload()
    {
        SceneManager.LoadScene("Level");
    }
}
