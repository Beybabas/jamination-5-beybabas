using System;
using UnityEngine;


public class HealthComponent : MonoBehaviour, IDamageable
{
    public int currentHealth;

    public event Action OnDie;

    public EnemyData enemyData;

    private void Awake()
    {
        currentHealth = enemyData.maxHealth;
    }


    public void Damage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            OnDie?.Invoke();
        }
    }
}