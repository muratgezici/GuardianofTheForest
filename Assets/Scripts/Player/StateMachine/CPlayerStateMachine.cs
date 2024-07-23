using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerStateMachine
{
    public CPlayerState CurrentPlayerState { get; set; }

    public void Initialize(CPlayerState startingState)
    {
        CurrentPlayerState = startingState;
        CurrentPlayerState.EnterState();
    }
    public void ChangeState(CPlayerState newState)
    {
        CurrentPlayerState.ExitState();
        CurrentPlayerState = newState;
        CurrentPlayerState.EnterState();
    }
}
