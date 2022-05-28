using System;
using Pathfinding;
using UnityEngine;


public class EnemyStateManager : MonoBehaviour
{

    public EnemyData enemyData;
    
    public EnemyBaseState currentState;

    public AIPath starAgent;

    [HideInInspector]  public Transform playerTransform;

    public SpriteRenderer spriteRenderer;

    public EnemyType enemyType;

    public RushToPlayerState rushToPlayerState = new RushToPlayerState();
    
    
    
    private void Awake()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
        spriteRenderer.sprite = enemyData.sprite;
        starAgent.maxSpeed = enemyData.moveSpeed;

        enemyType = enemyData.enemyType;
        
        InitialState();



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

    private void OnTriggerStay(Collider other)
    {
        
    }


    private void InitialState()
    {

        switch (enemyType)
        {
            case EnemyType.kamikaze:
                SwitchState(rushToPlayerState);
                break;
        }
        
    }
    
    
    
}