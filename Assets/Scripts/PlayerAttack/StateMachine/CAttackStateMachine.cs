using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAttackStateMachine
{
    public CAttackState CurrentAttackState { get; set; }

    public void Initialize(CAttackState startingState)
    {
        CurrentAttackState = startingState;
        CurrentAttackState.EnterState();
    }
    public void ChangeState(CAttackState newState)
    {
        CurrentAttackState.ExitState();
        CurrentAttackState = newState;
        CurrentAttackState.EnterState();
    }
}
