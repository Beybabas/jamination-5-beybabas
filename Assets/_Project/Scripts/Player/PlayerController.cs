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
   

   
}