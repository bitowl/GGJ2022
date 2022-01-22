using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    public float speed = 5;
    public float jumpForce = 3;
    public int groundLayer = 6;
    public bool canControlInAir = false;
    public float jumpCooldown = 0.1f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public PlayerData playerData;

    private bool doJump;
    private Vector2 movementInput;

    private Rigidbody rb;
    private int onGround;
    private float drag;
    private float nextJump = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        drag = rb.drag;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        /*if ()
        {
            doJump = true;
        }
        if (context.action.cancelled)
        {
            doJump = false;
        }*/
        doJump = context.action.triggered;
    }


    void Update()
    {
        if (nextJump > 0)
        {
            nextJump -= Time.deltaTime;
        }
        /*        if (Input.GetButtonDown("Jump"))
                {
                    doJump = true;
                }
                if (Input.GetButtonUp("Jump"))
                {
                    doJump = false;
                }*/
    }

    void FixedUpdate()
    {
        if (canControlInAir || onGround > 0)
        {
            /*float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");*/

            //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            Vector3 movement = new Vector3(movementInput.x, 0.0f, movementInput.y);

            rb.AddForce(movement * speed);
        }

        if (doJump && onGround > 0 && nextJump <= 0)
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            // doJump = false; // comment out 
            nextJump = jumpCooldown;
        }

        // Fall faster, ability to jump higher if jump is kept pressed
        if (rb.velocity.y < 0)
        {
            rb.AddForce(Physics.gravity * (fallMultiplier - 1), ForceMode.Acceleration);
        }
        else if (rb.velocity.y > 0 && !doJump)
        {
            rb.AddForce(Physics.gravity * (lowJumpMultiplier - 1), ForceMode.Acceleration);
        }

        // No drag in air
        rb.drag = onGround > 0 ? drag : 0;
    }


    // TODO fix when we can collide with two ground objects
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            onGround++;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            onGround--;
        }
    }
}
