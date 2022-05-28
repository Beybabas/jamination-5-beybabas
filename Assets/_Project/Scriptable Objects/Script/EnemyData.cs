using UnityEngine;


    [CreateAssetMenu(fileName = "Enemy", menuName = "EnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        
        public Sprite sprite;
        public float moveSpeed;
        public float contactRadius;

        public EnemyType enemyType;

        public int maxHealth;

        public int contactDamage;
        public int projectileDamage;
    }
