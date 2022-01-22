using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MockPlayer))]
public class MockPlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MockPlayer mockPlayer = target as MockPlayer;


        if (Application.isPlaying && GUILayout.Button("Take 10 damage"))
        {
            mockPlayer.playerData.currentHealth -= 10;
        }
    }
}
