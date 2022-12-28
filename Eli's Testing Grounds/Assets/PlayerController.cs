using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Speed of the player's movement
    public float speed = 5.0f;
    // Multiplier for speed when sprinting
    public float sprintSpeedMultiplier = 2.0f;
    // Force applied to the player when jumping
    public float jumpForce = 10.0f;
    // Minimum time between jumps
    public float jumpCooldown = 8.0f;
    // Reference to the player's rigidbody
    private Rigidbody rb;
    // Flag to track whether the player is sprinting
    private bool isSprinting = false;
    // Timer for the jump cooldown
    private float jumpTimer = 0.0f;
    // Counter for the number of jumps the player has made
    private int jumpCount = 0;
    // Maximum number of jumps the player can make within the jump cooldown period
    public int maxJumpCount = 2;
    // Sensitivity for turning with A and D keys
    public float turnSensitivity = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the player's rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Decrement the jump timer
        jumpTimer -= Time.deltaTime;

        // Get the input axes for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Check if the player is sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        // Calculate the movement vector based on the input axes and the player's speed
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;

        // Apply the sprint multiplier if the player is sprinting
        if (isSprinting)
        {
            movement *= sprintSpeedMultiplier;
        }

        // Rotate the movement vector to match the player's rotation
        movement = transform.rotation * movement;

        // Move the player
        transform.position += movement;

        // Check if the player wants to jump
        if (Input.GetKeyDown(KeyCode.Space) && jumpTimer <= 0.0f && jumpCount < maxJumpCount)
        {
            // Apply the jump force to the player's rigidbody
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            // Reset the jump timer
            jumpTimer = jumpCooldown;
            // Increment the jump count
            jumpCount++;
        }

        // Check if the player is on the ground
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.5f);

        // Check if the player wants to turn left or right
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.A))
            {
                // Rotate the player to the left
                transform.Rotate(Vector3.up, -turnSensitivity);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // Rotate the player to the right
                transform.Rotate(Vector3.up, turnSensitivity);
            }
        }
    }
}












