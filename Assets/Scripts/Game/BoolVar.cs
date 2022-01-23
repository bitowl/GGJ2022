using UnityEngine;

[CreateAssetMenu(menuName = "Game/Vars/Bool")]
public class BoolVar : ScriptableObject
{
    public bool initialValue;
    private bool _value;
    public bool value { get { return _value; } set { _value = value; } }

    private void OnEnable()
    {
        value = initialValue;
    }
}
