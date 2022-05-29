using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IDamageable
{
    public int CurrentHealth { get; set; } = 100;
    public void Damage(int amount)
    {
        Debug.Log("I am an obstacle!");
    }
}
