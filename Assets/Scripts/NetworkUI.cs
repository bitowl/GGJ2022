using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class NetworkUI : MonoBehaviour
{
    public Button startServerButton;
    public Button startHostButton;
    public Button startClientButton;

    void Start()
    {
        Cursor.visible = true;

        startServerButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartHost())
            {

            }
        });
        startHostButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartHost())
            {

            }
        });
        startClientButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartClient())
            {

            }
        });
    }

    // Update is called once per frame
    void Update()
    {
    }
}
