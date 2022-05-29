using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;

public class Bomb : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private int bombDamage = 50;
    [SerializeField] private float explosionRadius = 10;

    [SerializeField] private GameObject bombEffect;


    private void Awake()
    {
        transform.DOPunchScale(Vector3.one * 0.5f, 0.5f).SetDelay(1).OnComplete(
            () =>
                transform.DOPunchScale(Vector3.one * 0.5f, 0.25f).OnComplete(
                    () =>
                        transform.DOPunchScale(Vector3.one * 0.5f, 0.18f)).OnComplete(
                    () => transform.DOScale(Vector3.one * 2f, 0.18f).OnComplete(
                        () =>
                            AOEDmg()
                    )
                )
        );
    }

    void Start()
    {
    }


    private void AOEDmg()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (var hit in hits)
        {
            var aaa = hit.gameObject.GetComponent<IDamageable>();
            if (aaa != null)
            {
                aaa.Damage(bombDamage);
            }
        }

        GameObject spawnedBomb = Instantiate(bombEffect, transform.position, quaternion.identity);
        
        
        
        
        
        
        Destroy(gameObject);
    }


    void Update()
    {
    }
}