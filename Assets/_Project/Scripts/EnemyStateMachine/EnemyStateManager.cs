using System;
using Pathfinding;
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

    public RushToPlayerState rushToPlayerState = new RushToPlayerState();
    public DieState dieState = new DieState();

    public HealthComponent healthComponent;


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
                SwitchState(rushToPlayerState);
                break;
        }
    }


    private void ChangeDieState()
    {
        SwitchState(dieState);
    }
}