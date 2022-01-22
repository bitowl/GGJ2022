using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    [System.Serializable]
    public class PlayerConfig
    {

        //public InputDevice pairWithDevice;
        //public Transform spawnPoint;
        [Required]
        public CameraFollower camera;
        [Required]
        public PlayerData playerData;
    }

    public Level level;
    public PlayerConfig[] playerConfigs;

    /*    public GameObject player1Prefab;
        public GameObject player2Prefab;
        public CameraFollower camera1;
        public CameraFollower camera2;
        public Transform spawnPoint1;
        public Transform spawnPoint2;*/
    void Start()
    {
        int i = 0;
        foreach (var config in playerConfigs)
        {
            SpawnPlayer(i, config);
            //config.spawnPoint.position;
            i++;
        }
        /*
                var player1 = PlayerInput.Instantiate(player1Prefab, controlScheme: "P1_Keyboard", pairWithDevice: Keyboard.current);
                var player2 = PlayerInput.Instantiate(player2Prefab, controlScheme: "P2_Keyboard", pairWithDevice: Keyboard.current);
                camera1.target = player1.gameObject;
                camera2.target = player2.gameObject;
                player1.transform.position = spawnPoint1.position;
                player2.transform.position = spawnPoint2.position;*/
    }


    private void SpawnPlayer(int index, PlayerConfig config)
    {
        var player = PlayerInput.Instantiate(playerPrefab, controlScheme: level.playerChoices[index].controlScheme, pairWithDevice: Keyboard.current); // TODO add support for pairing with gamepads?
        GameObject gameObject = player.gameObject;
        Debug.Log(player.currentControlScheme);
        config.playerData.character = level.playerChoices[index].character;
        player.GetComponent<Player>().playerData = config.playerData;
        config.camera.target = gameObject;
        player.transform.position = level.spawnPoints[index].position; // TODO choose between multiple spawn positions?

        // Instantiate character
        GameObject characterModel = Instantiate(level.playerChoices[index].character.modelPrefab, Vector3.zero, Quaternion.identity);
        characterModel.transform.SetParent(gameObject.transform, false);
        config.playerData.charComponent = characterModel.GetComponent<Character>();

        gameObject.name = $"Player{index}";
    }
}
