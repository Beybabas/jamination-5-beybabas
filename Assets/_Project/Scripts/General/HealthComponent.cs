using System;
using UnityEngine;


public class HealthComponent : MonoBehaviour, IDamageable
{
    public event Action OnDie;

    public bool isPlayer;
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