using UnityEngine;


public class DieState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.SetParticleEffect();
        GameObject.Destroy(enemy.gameObject);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
    }

    public override void ExitState(EnemyStateManager enemy)
    {
    }
}