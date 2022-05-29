using UnityEngine;


public class ApproachState : EnemyBaseState
{
    private float elapsedTime = 0;
    public override void EnterState(EnemyStateManager enemy)
    {
        elapsedTime = 0;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        enemy.starAgent.destination = enemy.playerTransform.position;
        enemy.transform.up = (enemy.playerTransform.position-enemy.transform.position).normalized;
        
        elapsedTime += Time.deltaTime;
        
        if (elapsedTime > 0.1f)
        {
            elapsedTime = 0;

            if (Vector2.Distance(enemy.playerTransform.position,enemy.transform.position) < ArrivalDistanceHolder.SEEK_RANGE )
            {

                enemy.starAgent.destination = enemy.transform.position;
                if (enemy.enemyType == EnemyType.ranger)
                {
                    enemy.SwitchState(enemy.rangerAttackState);
                }else if (enemy.enemyType == EnemyType.rotator)
                {
                    enemy.SwitchState(enemy.spinAndAttakState);
                }

                
            }
        }
    }

    public override void ExitState(EnemyStateManager enemy)
    {
       
    }
}