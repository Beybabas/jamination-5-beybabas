using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputX;
    private bool jumpInput;
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private float groundCheckRadius;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetButton("Jump");

        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);

        if (jumpInput && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (inputX != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(inputX), 1, 1);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayer);
    }
}