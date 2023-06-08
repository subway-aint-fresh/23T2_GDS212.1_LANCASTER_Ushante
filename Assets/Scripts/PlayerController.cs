using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;           // Player movement speed
    public LayerMask groundLayer;          // Layer(s) considered as ground
    public float groundCheckDistance = 2f; // Distance to check for ground contact
    public float slopeFactor = 10f;        // Factor to control rolling down hills
    public float externalForce = 2f;       // Magnitude of the external force

    [SerializeField] private bool isGrounded = false;  // Flag to check if the player is grounded

    private Rigidbody rb;                  // Reference to the player's Rigidbody component

    public GameObject wagonFire;           // Reference to the fire particles on the player controller

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
            if (Physics.Raycast(transform.position, Vector3.up, out hit, groundCheckDistance, groundLayer))
            {
                float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);
                movement += hit.normal * slopeFactor * slopeAngle;
            }
        }

        // Add external force to the movement
        movement += transform.forward * externalForce;

        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If player collides with an object with the 'WaterHazard' tag
        if (other.CompareTag("WaterHazard"))
        {
            // Stop player movement
            moveSpeed = 0f;
            externalForce = 0f;

            // Set fire particle on player controller to inactive
            wagonFire.SetActive(false);

            // Throw up replay/back to main menu prompt

        }
    }
}
