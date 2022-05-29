using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class SpinAndAttakState : EnemyBaseState
{
    private float elapsedTime;
    private Vector3[] firePositions;

    private bool raySwitch;
    private int rayCount;
    public override void EnterState(EnemyStateManager enemy)
    {
        firePositions = GetSpawnPositions(enemy,20);
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1f)
        {
            if (raySwitch)
            {
                raySwitch = false;
                rayCount = 15;
            }
            else
            {
                raySwitch = true;
                rayCount = 13;
            }

            foreach (var position in GetSpawnPositions(enemy,rayCount))
            {
                enemy.FireProjectile(position,1,50);
            }

            enemy.transform.DOPunchScale(Vector3.one * 0.3f, 0.3f).OnComplete(()=> enemy.transform.DORotate(new Vector3(0,0, enemy.transform.eulerAngles.z+30),0.25f));
            
            
            elapsedTime = 0;
        }
        
       
        
        
    }

    public override void ExitState(EnemyStateManager enemy)
    {
    }


    private Vector3[] GetSpawnPositions(EnemyStateManager enemy,float angleBetweenRays)
    {
        
        
        
        int spawnPositionCount = Mathf.FloorToInt(360 / angleBetweenRays) + 1;;
        
        Vector3[] spawnDirections = new Vector3[spawnPositionCount];
        for (int i = 0; i < spawnPositionCount; i++)
        {
            Vector3 v = Vector3.right;
            v = Quaternion.AngleAxis(angleBetweenRays * i, Vector3.forward) * v;
            spawnDirections[i] = v;
        }

        return spawnDirections;
    }
    
    
    
}