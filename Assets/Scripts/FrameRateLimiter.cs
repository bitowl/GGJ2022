using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    public int targetFrameRate = 60;

    // http://answers.unity.com/answers/560545/view.html
    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = targetFrameRate;
    }
}
