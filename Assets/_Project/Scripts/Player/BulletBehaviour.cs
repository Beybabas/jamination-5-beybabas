using System;
using UnityEngine;


public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private BulletData singleShot;
    [SerializeField] private BulletData bigShot;
    [HideInInspector] public BulletData currentBullet;
    [SerializeField] private GameObject hitParticle;
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
        if (col.TryGetComponent(out IDamageable idamageable))
        {
            if (col.GetComponent<PlayerController>()) return;

            if (currentBullet.damage < idamageable.CurrentHealth) SetHitParticle();

            CinemachineShake.Instance.ShakeCamera(2f, .1f); // Maybe when enemy dies? 
            idamageable.Damage(currentBullet.damage);
            BulletDestroyer();
        }
    }

    public void SetHitParticle()
    {
        if (hitParticle != null) Instantiate(hitParticle, transform.position, Quaternion.identity);
    }


    private void BulletDestroyer(float deadTimer = 0f)
    {
        Destroy(gameObject, deadTimer);
    }
}