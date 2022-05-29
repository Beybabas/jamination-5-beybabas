using System;
using UnityEngine;


public class HealthComponent : MonoBehaviour, IDamageable
{
    public bool isPlayer;
    public event Action OnDie;

    public EnemyData enemyData;

    private void Awake()
    {
        CurrentHealth = enemyData.maxHealth;
    }


    public int CurrentHealth { get; set; }

    public void Damage(int amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            if (isPlayer) GameManager.instance.OnGameOver?.Invoke();
            OnDie?.Invoke();
        }
    }
}