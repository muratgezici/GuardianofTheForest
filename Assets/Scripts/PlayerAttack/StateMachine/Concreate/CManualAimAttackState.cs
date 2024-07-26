using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CManualAimAttackState : CAttackState
{
    public CManualAimAttackState(CAttackBase attackbase, CAttackStateMachine attackStateMachine) : base(attackbase, attackStateMachine)
    {
    }

    public override void AnimationTriggerEvent(CPlayer.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        AttackBase.ActivateWeapons();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        
        if (AttackBase.IsAutoAimEnabled)
        {
            AttackBase.StateMachine.ChangeState(AttackBase.AutoAimState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
