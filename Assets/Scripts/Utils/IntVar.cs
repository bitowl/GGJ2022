using UnityEngine;
[CreateAssetMenu(menuName = "Game/Vars/Int")]
public class IntVar : ScriptableObject
{
    public int initialValue;
    private int _value;
    public int value { get { return _value; } set { _value = value; } }

    private void OnEnable()
    {
        value = initialValue;
    }
}
