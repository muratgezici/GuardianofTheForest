using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyStateMachine
{
   public CEnemyState CurrentEnemyState {  get; set; }

    public void Initialize(CEnemyState startingState)
    {
        CurrentEnemyState = startingState;
        CurrentEnemyState.EnterState();
    }
    public void ChangeState(CEnemyState newState)
    {
        CurrentEnemyState.ExitState();
        CurrentEnemyState = newState;
        CurrentEnemyState.EnterState();
    }
}
