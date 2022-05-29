using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private int _bulletDamage;
    private float _bulletForce;

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
        Destroy(gameObject, deadTimer);
    }
}