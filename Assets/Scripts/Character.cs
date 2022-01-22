using UnityEngine;

public class Character : MonoBehaviour
{
    [System.Serializable]
    public class DestructionMesh
    {
        [Tooltip("Above which health this game object is shown")]
        public float moreThan;
        public GameObject gameObject;
    }
    [Tooltip("Collider that should be moved to the player object")]
    public Collider colliderToMove;
    public DestructionMesh[] destructionMeshes;
}
