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

    [SerializeField] private HealthComponent _healthComponent;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _healthComponent.OnDie += GameManager.instance.GameOver;
    }

    private void OnDisable()
    {
        _healthComponent.OnDie -= GameManager.instance.GameOver;
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");


        rb.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);

       


    }
   

   
}