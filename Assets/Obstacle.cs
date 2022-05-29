using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour, IDamageable
{
    [SerializeField] private SpriteRenderer renderer;


    private void Start()
    {
        renderer.color = Random.ColorHSV(0f, 1f, 0.4f, 0.8f, 0.6f, 1f);
    }

    public int CurrentHealth { get; set; } = 100;
    public void Damage(int amount)
    {
        Debug.Log("I am an obstacle!");
    }
}
