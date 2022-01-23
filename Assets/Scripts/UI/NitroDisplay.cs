using UnityEngine;
using UnityEngine.UI;

public class NitroDisplay : MonoBehaviour
{
    public PlayerData playerData;
    public Slider slider;

    void Update()
    {
        slider.value = playerData.currentNitro / playerData.maxNitro;
    }
}
