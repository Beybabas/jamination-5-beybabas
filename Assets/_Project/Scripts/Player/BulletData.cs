using UnityEngine;


[CreateAssetMenu(fileName = "Bullet", menuName = "bulletData", order = 0)]
public class BulletData : ScriptableObject
{

    [SerializeField] private Sprite sprite;
    
    [SerializeField] private float projectileSpeed;
}