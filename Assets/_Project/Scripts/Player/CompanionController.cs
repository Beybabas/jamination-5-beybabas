using System;
using UnityEngine;


public class CompanionController : MonoBehaviour
{
    [SerializeField] private float inputForce;

    private Rigidbody2D rb;

    private Vector2 inputVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");


        rb.AddForce(inputVector * inputForce, ForceMode2D.Force);
    }
}