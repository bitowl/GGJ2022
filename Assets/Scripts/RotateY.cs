using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{
    public float speed = 200;
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
