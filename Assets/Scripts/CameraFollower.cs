using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollower : MonoBehaviour
{
    public GameObject target;
    private Camera cam;
    private static Vector3 initialOffset = new Vector3(0.19f, -11f, 2.8f);
    public Vector3 offset = initialOffset;
    private float z;
    void Start()
    {
        cam = GetComponent<Camera>();
        //offset = target.transform.position - cam.transform.position;
        //z =
        // TODO tmp workaround as the initialOffset is not set in some scenes?
        if (offset == Vector3.zero)
        {
            offset = initialOffset;
        }
    }

    void Update()
    {
        if (target)
        {
            transform.position = target.transform.position - offset;
        }
    }
}
