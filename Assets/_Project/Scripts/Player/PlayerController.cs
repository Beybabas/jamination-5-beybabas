using System;
using Unity.Mathematics;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputX;
    private float inputY;

    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform playerSprite;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");


        rb.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);

       


    }
    

    private void FixedUpdate()
    {
        // RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, 2, groundLayer);
        //
        // if (hit2D.collider != null)
        // {
        //     float targetRotationAngle = -(90 - Vector2.Angle(hit2D.normal, Vector2.right));
        //
        //     transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetRotationAngle),
        //         groundRotationSpeed * Time.deltaTime);
        //     //transform.rotation = Quaternion.Euler(0, 0, targetRotationAngle);
        // }
    }

   
}