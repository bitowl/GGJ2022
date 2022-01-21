using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    public float speed = 5;
    public float jumpForce = 3;
    public int groundLayer = 6;
    public bool canControlInAir = false;

    private Rigidbody rb;
    private bool doJump;
    private bool onGround;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            doJump = true;
        }
    }

    void FixedUpdate()
    {
        if (canControlInAir || onGround)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }

        if (doJump && onGround)
        {
            rb.AddForce(jumpForce * Vector3.up);
            doJump = false;
        }
    }


    // TODO fix when we can collide with two ground objects
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            onGround = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            onGround = false;
        }
    }
}
