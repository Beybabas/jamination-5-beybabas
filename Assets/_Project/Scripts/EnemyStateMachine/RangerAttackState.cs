using System.Collections;
using UnityEngine;


public class RangerAttackState : EnemyBaseState
{
    private float elapsedTime;

    public override void EnterState(EnemyStateManager enemy)
    {
        
        
        enemy.StartCoroutine(RangerAttackSequence(enemy));
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        elapsedTime = Time.deltaTime;
        
        Debug.Log(Vector2.Distance(enemy.playerTransform.position, enemy.transform.position));
        if (elapsedTime > 0.1f)
        {
           
            Debug.Log("girdi");
            if (Vector2.Distance(enemy.playerTransform.position, enemy.transform.position) > ArrivalDistanceHolder.SEEK_RANGE + 2.5f)
            {
                Debug.Log("approach state");
                enemy.StopAllCoroutines();
                enemy.SwitchState(enemy.approachState);
            }
            elapsedTime = 0;
        }
    }

    public override void ExitState(EnemyStateManager enemy)
    {
    }



    private IEnumerator RangerAttackSequence(EnemyStateManager enemy)
    {
        for (int i = 0; i < 3; i++)
        {
            
            yield return new WaitForSeconds(0.5f);
        }

        var dirToPlayer = (enemy.playerTransform.position - enemy.transform.position).normalized;
        
        enemy.FireProjectile(dirToPlayer,enemy.bulletForce,enemy.bulletDamage);
        
        
        enemy.SwitchState(enemy.rangerAttackState);
    }
}