using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAttackState
{
    protected CAttackBase AttackBase;
    protected CAttackStateMachine AttackStateMachine;
    protected bool IsGameStopped = false;
    private void SetIsGameStopped(bool val)
    {
        IsGameStopped = val;
    }
    public CAttackState(CAttackBase attackbase, CAttackStateMachine attackStateMachine)
    {
        this.AttackBase = attackbase;
        this.AttackStateMachine = attackStateMachine;
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
