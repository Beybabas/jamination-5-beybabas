using UnityEngine;


public class EnemyStateManager : MonoBehaviour
{

    public EnemyBaseState currentState;
    
    
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
    
}