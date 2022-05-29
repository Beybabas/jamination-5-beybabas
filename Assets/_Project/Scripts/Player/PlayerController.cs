using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float inputX;
    private float inputY;

    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform playerSprite;

    [SerializeField] private HealthComponent _healthComponent;

    [Header("Dash Settings")] 

    
    [SerializeField] private float _dashVelocity;
    
    [SerializeField] private float _dashTime;
    private Vector2 _dashDir;
    private bool _canDash=true;
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

            _dashDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (_dashDir == Vector2.zero)
            {
                _dashDir = new Vector2(Random.Range(0,2), Random.Range(0,2));
            }

            StartCoroutine(StopDashing());
        }

        if (_isDashing)
        {
            rb.velocity = _dashDir.normalized * _dashVelocity;
            return;
            
        }
        
        
        
        

        rb.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);

       


    }


    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashTime);
        _isDashing = false;
        _canDash = true;
    }



}