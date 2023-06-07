using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;         // Player movement speed
    public LayerMask groundLayer;        // Layer(s) considered as ground
    public float groundCheckDistance = 0.1f; // Distance to check for ground contact
    public float slopeFactor = 5f;       // Factor to control rolling down hills

    [SerializeField] private bool isGrounded = false;  // Flag to check if the player is grounded

    private Rigidbody rb;                // Reference to the player's Rigidbody component

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

        // Apply slope factor based on the ground normal to roll down hills
        if (isGrounded)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer))
            {
                float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);
                movement += hit.normal * slopeFactor * slopeAngle;
            }
        }

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}

