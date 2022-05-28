using UnityEngine;


public class DieState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        GameObject.Destroy(enemy.gameObject);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
       
    }

    public override void ExitState(EnemyStateManager enemy)
    {
        
    }
}