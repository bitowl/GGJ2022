using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public PlayerData playerData;
    public Slider slider;

    void Update()
    {
        slider.value = playerData.currentHealth / playerData.maxHealth;
    }
}
