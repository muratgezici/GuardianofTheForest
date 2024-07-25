using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAttackState
{
    protected CAttackBase AttackBase;
    protected CAttackStateMachine AttackStateMachine;


    public CAttackState(CAttackBase attackbase, CAttackStateMachine attackStateMachine)
    {
        this.AttackBase = attackbase;
        this.AttackStateMachine = attackStateMachine;

    }
    public virtual void EnterState()
    {

    }
    public virtual void ExitState()
    {

    }
    public virtual void FrameUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {

    }
    public virtual void AnimationTriggerEvent(CPlayer.AnimationTriggerType triggerType)
    {

    }
}
