using UnityEngine;


public interface IDamageable
{
    public int CurrentHealth { get; set; }
    public void Damage(int amount);

}