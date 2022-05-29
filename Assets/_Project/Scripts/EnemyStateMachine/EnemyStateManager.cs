using System;
using Pathfinding;
using Unity.Mathematics;
using UnityEngine;


public class EnemyStateManager : MonoBehaviour
{
    public EnemyData enemyData;

    public GameObject hitParticle;

    public EnemyBaseState currentState;

    public AIPath starAgent;

    [HideInInspector] public Transform playerTransform;

    public SpriteRenderer spriteRenderer;

    public EnemyType enemyType;


    public DieState dieState = new DieState();

    public HealthComponent healthComponent;

    public EnemyBulletBehaviour enemyBullet;
    public int bulletDamage;
    public float bulletForce;
    public LineRenderer rayRenderer;

    public RushToPlayerState rushToPlayerState = new RushToPlayerState();
    public ApproachState approachState = new ApproachState();
    public RangerAttackState rangerAttackState = new RangerAttackState();
    public SpinAndAttakState spinAndAttakState = new SpinAndAttakState();
    

    public void SetParticleEffect()
    {
        Instantiate(hitParticle, transform.position, Quaternion.identity);
    }

    private void Awake()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;

        spriteRenderer.sprite = enemyData.sprite;
        starAgent.maxSpeed = enemyData.moveSpeed;

        enemyType = enemyData.enemyType;

        InitialState();
    }

    private void OnEnable()
    {
        healthComponent.OnDie += ChangeDieState;
    }

    private void OnDisable()
    {
        healthComponent.OnDie -= ChangeDieState;
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState state)
    {
        state.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
    }


    private void InitialState()
    {
        switch (enemyType)
        {
            case EnemyType.kamikaze:
                SwitchState(rushToPlayerState);
                break;
            case EnemyType.ranger:
                SwitchState(approachState);
                break;
            case EnemyType.rotator:
                SwitchState(approachState);
                break;
        }
    }


    private void ChangeDieState()
    {
        SwitchState(dieState);
    }


    public void FireProjectile(Vector2 bulletDir, float bulletForce, int bulletDamage)
    {
        var bulletBehaviour = Instantiate(enemyBullet, transform.position, quaternion.identity);
        bulletBehaviour.FireBullet(bulletDir, bulletForce, bulletDamage);
    }
}