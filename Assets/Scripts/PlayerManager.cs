using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player2Prefab;
    public CameraFollower camera1;
    public CameraFollower camera2;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    void Start()
    {
        var player1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "P1_Keyboard", pairWithDevice: Keyboard.current);
        var player2 = PlayerInput.Instantiate(player2Prefab, controlScheme: "P2_Keyboard", pairWithDevice: Keyboard.current);
        camera1.target = player1.gameObject;
        camera2.target = player2.gameObject;
        player1.transform.position = spawnPoint1.position;
        player2.transform.position = spawnPoint2.position;
    }
}
