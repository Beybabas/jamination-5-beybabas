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

    [Header("Dash Settings")] [SerializeField]
    private TrailRenderer _dashTrail;

    
    [SerializeField] private float _dashVelocity;
    
    [SerializeField] private float _dashTime;
    private Vector2 _dashDir;
    private bool _canDash;
    private bool _isDashing;
    
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /*private void OnEnable()
    {
        _healthComponent.OnDie += GameManager.instance.GameOver;
    }

    private void OnDisable()
    {
        _healthComponent.OnDie -= GameManager.instance.GameOver;
    }*/

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        var dashInput = Input.GetKeyDown(KeyCode.Space);

        if (dashInput && _canDash)
        {
            _isDashing = true;
            _canDash = false;
            _dashTrail.emitting = true;
        }
        
        

        rb.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);

       


    }
   

   
}