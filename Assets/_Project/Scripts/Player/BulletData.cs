using UnityEngine;


[CreateAssetMenu(fileName = "Bullet", menuName = "bulletData", order = 0)]
public class BulletData : ScriptableObject
{

    public Sprite sprite;
    
    public float projectileSpeed;
    public float bulletForce;
    public float delayTime;
}