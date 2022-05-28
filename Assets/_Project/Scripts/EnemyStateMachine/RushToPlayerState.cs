using UnityEngine;


public class RushToPlayerState : EnemyBaseState
{
    private float elapsedTime = 0;
    public override void EnterState(EnemyStateManager enemy)
    {
        elapsedTime = 0;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.starAgent.destination = enemy.playerTransform.position;

        elapsedTime += Time.deltaTime;

        if (elapsedTime > 0.1f)
        {
            elapsedTime = 0;

            if (Vector2.Distance(enemy.playerTransform.position,enemy.transform.position) < ArrivalDistanceHolder.CLOSE_RANGE )
            {
                enemy.SwitchState(enemy.dieState);
            }
        }

    }

    public override void ExitState(EnemyStateManager enemy)
    {
        
    }
}