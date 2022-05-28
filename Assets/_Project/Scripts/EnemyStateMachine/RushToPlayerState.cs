using UnityEngine;


public class RushToPlayerState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.starAgent.destination = enemy.playerTransform.position;
    }

    public override void ExitState(EnemyStateManager enemy)
    {
        
    }
}