using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;         // Player movement speed
    public float jumpForce = 5f;         // Jump force
    public LayerMask groundLayer;        // Layer(s) considered as ground
    public float groundCheckDistance = 0.1f; // Distance to check for ground contact

    private Rigidbody rb;                // Reference to the player's Rigidbody component
    private bool isGrounded = false;     // Check if the player is grounded

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if the player is grounded using a raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        // Handle player movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector3 movement = new Vector3(moveInput, 0f, 0f) * moveSpeed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Handle player jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }
    }
}
