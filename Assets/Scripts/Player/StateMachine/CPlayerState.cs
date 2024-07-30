using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerState 
{
    protected CPlayer player;
    protected CPlayerStateMachine PlayerStateMachine;
    protected bool IsGameStopped = false;
    private void SetIsGameStopped(bool val)
    {
        IsGameStopped = val;
    }
    public CPlayerState(CPlayer player, CPlayerStateMachine playerStateMachine)
    {
        this.player = player;
        this.PlayerStateMachine = playerStateMachine;
        CGameManager.IsGamePausedEvent += SetIsGameStopped;
    }
    public virtual void EnterState()
    {

    }
    public virtual void ExitState()
    {

    }
    public virtual void FrameUpdate()
    {
        if (IsGameStopped)
        {
            return;
        }
    }
    public virtual void PhysicsUpdate()
    {
        if (IsGameStopped)
        {
            return;
        }
    }
    public virtual void AnimationTriggerEvent(CPlayer.AnimationTriggerType triggerType)
    {
        
    }
}
