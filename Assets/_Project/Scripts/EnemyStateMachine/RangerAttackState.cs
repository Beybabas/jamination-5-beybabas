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
        elapsedTime += Time.deltaTime;

        //Debug.Log(Vector2.Distance(enemy.playerTransform.position, enemy.transform.position));
        if (elapsedTime > 0.1f)
        {
            if (Vector2.Distance(enemy.playerTransform.position, enemy.transform.position) > ArrivalDistanceHolder.SEEK_RANGE * 2.5)
            {
                enemy.StopAllCoroutines();
                enemy.SwitchState(enemy.approachState);
            }


            elapsedTime = 0;
        }


        enemy.transform.up = (enemy.playerTransform.position - enemy.transform.position).normalized;
        
        enemy.rayRenderer.SetPosition(0, enemy.transform.position+enemy.transform.up*0.4f);
        enemy.rayRenderer.SetPosition(1, enemy.playerTransform.position);
    }

    public override void ExitState(EnemyStateManager enemy)
    {
    }


    private IEnumerator RangerAttackSequence(EnemyStateManager enemy)
    {
        

        float a = 0.15f;
        float b = 0.6f;

        for (int i = 1; i <= 4; i++)
        {
            enemy.rayRenderer.endWidth = 0f;
            enemy.rayRenderer.startWidth = 0f;

            yield return new WaitForSeconds(a / i);

            enemy.rayRenderer.endWidth =enemy.tmpWidth;
            enemy.rayRenderer.startWidth = enemy.tmpWidth;

            yield return new WaitForSeconds(b / i);
        }

        enemy.rayRenderer.endWidth = 0f;
        enemy.rayRenderer.startWidth = 0f;

        yield return new WaitForSeconds(0.25f);


        var dirToPlayer = (enemy.playerTransform.position - enemy.transform.position).normalized;

        enemy.FireProjectile(dirToPlayer, enemy.bulletForce, enemy.enemyData.projectileDamage);


        enemy.SwitchState(enemy.rangerAttackState);
    }
}