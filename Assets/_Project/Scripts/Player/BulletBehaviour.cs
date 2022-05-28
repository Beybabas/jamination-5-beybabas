using System;
using UnityEngine;


public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private BulletData singleShot;
    [HideInInspector] public BulletData currentBullet;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private SpriteRenderer spriteRenderer;
    
    
    public void SelectSingleShot()
    {
        currentBullet = singleShot;
        spriteRenderer.sprite = currentBullet.sprite;
    }

    private void Awake()
    {
        
        //SetCurrentBullet(singleShot);
    }

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    public void AddForce(Vector2 bulletDir)
    {
        rb.AddForce(bulletDir * currentBullet.bulletForce, ForceMode2D.Impulse);
    }
}