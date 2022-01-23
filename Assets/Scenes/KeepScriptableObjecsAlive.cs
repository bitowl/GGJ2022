using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepScriptableObjecsAlive : MonoBehaviour
{
    private static KeepScriptableObjecsAlive instance;

    // Just keep a reference to all scriptable objects that are modified at runtime, so the changes are not lost in a scene that does not reference them.
    // http://answers.unity.com/answers/1553557/view.html
    public ScriptableObject[] scriptableObjects;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
