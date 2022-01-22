using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [System.Serializable]
    public class PlayerConfig
    {
        public GameObject playerPrefab;
        public string controlScheme;
        public InputDevice pairWithDevice;
        public Transform spawnPoint;
        public CameraFollower camera;
        public PlayerData playerData;
        public CharacterData character;
    }

    public PlayerConfig[] playerConfigs;

    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public CameraFollower camera1;
    public CameraFollower camera2;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    void Start()
    {
        foreach (var config in playerConfigs)
        {
            var player = PlayerInput.Instantiate(config.playerPrefab, controlScheme: config.controlScheme, pairWithDevice: Keyboard.current); // TODO add support for pairing with gamepads?
            Debug.Log(player.currentControlScheme);
            config.playerData.character = config.character;
            player.GetComponent<Player>().playerData = config.playerData;
            config.camera.target = player.gameObject;
            player.transform.position = config.spawnPoint.position;
        }
        /*
                var player1 = PlayerInput.Instantiate(player1Prefab, controlScheme: "P1_Keyboard", pairWithDevice: Keyboard.current);
                var player2 = PlayerInput.Instantiate(player2Prefab, controlScheme: "P2_Keyboard", pairWithDevice: Keyboard.current);
                camera1.target = player1.gameObject;
                camera2.target = player2.gameObject;
                player1.transform.position = spawnPoint1.position;
                player2.transform.position = spawnPoint2.position;*/
    }
}
