using UnityEngine;

public class Character : MonoBehaviour
{
    [System.Serializable]
    public class DestructionMesh
    {
        [Tooltip("Above which percent health (0 to 1) this game object is shown")]
        public float moreThan;
        public GameObject gameObject;
    }
    [Tooltip("Collider that should be moved to the player object")]
    public Collider colliderToMove;
    public DestructionMesh[] destructionMeshes;

    public void ShowModelForHealth(float healthPercentage)
    {
        Debug.Log($"SHOW FOR {healthPercentage}");
        bool found = false;
        foreach (var mesh in destructionMeshes)
        {
            if (found)
            {
                mesh.gameObject.SetActive(false);
            }
            else
            {
                if (healthPercentage >= mesh.moreThan)
                {
                    mesh.gameObject.SetActive(true);
                    found = true;
                }
                else
                {
                    mesh.gameObject.SetActive(false);
                }
            }
        }
    }
}
