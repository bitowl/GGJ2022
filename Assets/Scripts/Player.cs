using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
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
    public float rotateSpeed = 50f;

    private bool doJump;
    private Vector2 movementInput;

    private Rigidbody rb;
    /*[ReadOnly]
    public int onGround;*/
    private float drag;
    private float nextJump = 0;
    private float rotate = 0;
    private bool useNitro = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        drag = rb.drag;

        playerData.maxNitro = playerData.character.maxNitroSeconds;
        playerData.currentNitro = playerData.character.maxNitroSeconds;
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

    public void OnNitro(InputAction.CallbackContext context)
    {
        useNitro = context.action.triggered;
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        if (playerData.character.hasRotateControls)
        {
            float value = context.ReadValue<float>();
            rotate = value;
        }
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
        float speedMultiplier = 1;

        // Use nitro
        if (useNitro && playerData.currentNitro > 0)
        {
            playerData.currentNitro -= Time.deltaTime;
            speedMultiplier = playerData.character.nitroSpeedMultiplier;
        }


        if (canControlInAir || groundTouched.Count > 0)
        {
            /*float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");*/

            //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            Vector3 movement = new Vector3(movementInput.x, 0.0f, movementInput.y);

            rb.AddForce(movement * speed * speedMultiplier);
        }

        if (doJump && groundTouched.Count > 0 && nextJump <= 0)
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

        // Add torge to rotate long objects
        if (rotate != 0)
        {
            rb.AddTorque(Vector3.up * rotate * rotateSpeed, ForceMode.Acceleration);
        }


        // No drag in air
        rb.drag = groundTouched.Count > 0 ? drag : 0;
    }


    private List<Collider> groundTouched = new List<Collider>();

    // TODO fix when we can collide with two ground objects
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == groundLayer && !groundTouched.Contains(collision.collider))
        {
            groundTouched.Add(collision.collider);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == groundLayer && groundTouched.Contains(collision.collider))
        {
            groundTouched.Remove(collision.collider);
        }
    }

    public void AddNitro(float amount)
    {
        playerData.currentNitro += amount;
        playerData.currentNitro = Mathf.Clamp(playerData.currentNitro, 0, playerData.maxNitro);
    }
}
