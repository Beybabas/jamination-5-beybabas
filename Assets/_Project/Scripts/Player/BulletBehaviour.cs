using System;
using UnityEngine;


public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private BulletData singleShot;
    [SerializeField] private BulletData bigShot;
    [HideInInspector] public BulletData currentBullet;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private SpriteRenderer spriteRenderer;


    public void SelectSingleShot()
    {
        currentBullet = singleShot;
        spriteRenderer.sprite = currentBullet.sprite;

        transform.localScale = currentBullet.bulletScale;
    }


    public void SelectBigShot()
    {
        currentBullet = bigShot;
        spriteRenderer.sprite = currentBullet.sprite;

        transform.localScale = currentBullet.bulletScale;
    }


    private void Awake()
    {
        //SetCurrentBullet(singleShot);
    }

    private void Start()
    {
        BulletDestroyer(currentBullet.deadTimer);
    }

    public void AddForce(Vector2 bulletDir)
    {
        rb.AddForce(bulletDir * currentBullet.bulletForce, ForceMode2D.Impulse);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        var enemyBaseState = col.GetComponent<EnemyStateManager>();
        if (enemyBaseState != null)
        {
            if (col.TryGetComponent(out IDamageable idamageable))
            {
                idamageable.Damage(currentBullet.damage);

                BulletDestroyer();
            }
        }
    }


    private void BulletDestroyer(float deadTimer = 0f)
    {
        Destroy(gameObject, deadTimer);
    }
}