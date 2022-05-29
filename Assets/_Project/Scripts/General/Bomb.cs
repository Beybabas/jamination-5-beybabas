using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class Bomb : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    [SerializeField] private AudioClip[] clip;
    
    [SerializeField] private int bombDamage = 50;
    [SerializeField] private float explosionRadius = 10;

    [SerializeField] private GameObject bombEffect;


    private void Awake()
    {
        transform.DOPunchScale(Vector3.one * 0.5f, 0.5f).OnComplete(
            () =>
                transform.DOPunchScale(Vector3.one * 0.5f, 0.3f).OnComplete(
                    () =>
                        transform.DOPunchScale(Vector3.one * 0.5f, 0.1f)).OnComplete(
                    () => transform.DOScale(Vector3.one * 2.5f, 0.1f).OnComplete(
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

        SoundManager.Instance.PlayBombSound(clip[Random.Range(0, clip.Length)]);
        GameObject spawnedBomb = Instantiate(bombEffect, transform.position, quaternion.identity);
        
        
        
        
        
        
        Destroy(gameObject);
    }


    void Update()
    {
    }
}