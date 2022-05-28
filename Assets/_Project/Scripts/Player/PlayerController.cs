using System;
using Unity.Mathematics;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputX;
    private bool jumpInput;
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float groundRotationSpeed;


    [SerializeField] private LayerMask groundLayer;
    private LayerMask gLayer;

    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private float groundCheckRadius;


    [SerializeField] private Transform playerSprite;


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

        playerSprite.transform.Rotate(0.0f, 0.0f, inputX * -rotateSpeed);


        if (inputX != 0)
        {
            //transform.localScale = new Vector3(Mathf.Sign(inputX), 1, 1);
        }
    }


    private void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, 2, groundLayer);
   
        if (hit2D.collider != null)
        {

            float targetRotationAngle = -(90 - Vector2.Angle(hit2D.normal, Vector2.right));

            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0, 0, targetRotationAngle), groundRotationSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(0, 0, targetRotationAngle);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayer);
    }
}