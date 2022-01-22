using UnityEngine;
[CreateAssetMenu(menuName = "Game/Vars/Float")]
public class FloatVar : ScriptableObject
{
    public float initialValue;
    private float _value;
    public float value { get { return _value; } set { _value = value; } }

    private void OnEnable()
    {
        value = initialValue;
    }
}
