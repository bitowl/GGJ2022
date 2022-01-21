using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollower : MonoBehaviour
{
    public GameObject target;
    private Camera cam;
    private Vector3 offset;
    private float z;
    void Start()
    {
        cam = GetComponent<Camera>();
        offset = target.transform.position - cam.transform.position;
        //z =
    }

    void Update()
    {
        transform.position = target.transform.position - offset;
    }
}
