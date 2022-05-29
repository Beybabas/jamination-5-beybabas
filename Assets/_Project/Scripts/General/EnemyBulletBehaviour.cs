using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject particle;
    
    private int _bulletDamage;
    private float _bulletForce;

    private HealthComponent _healthComponent;


    private void Awake()
    {
        _healthComponent = GetComponent<HealthComponent>();
    }

    private void OnEnable()
    {
        _healthComponent.OnDie += () => Destroy(gameObject);
    }

    


    public void FireBullet(Vector2 bulletDir, float bulletForce, int bulletDamage)
    {
        _bulletForce = bulletForce;
        _bulletDamage = bulletDamage;
        rb.AddForce(bulletDir*_bulletForce, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        var playerController = col.GetComponent<PlayerController>();
        if (playerController != null)
        {
            if (col.TryGetComponent(out IDamageable idamageable))
            {
                idamageable.Damage(_bulletDamage);
                BulletDestroyer();
            }
        }
    }

    private void BulletDestroyer(float deadTimer = 0f)
    {
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject, deadTimer);
    }
}