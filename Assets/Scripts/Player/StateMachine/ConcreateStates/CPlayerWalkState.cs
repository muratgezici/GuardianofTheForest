using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerWalkState : CPlayerState
{
    public CPlayerWalkState(CPlayer player, CPlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void AnimationTriggerEvent(CPlayer.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
        player.transform.GetChild(0).GetComponent<Animator>().Play("Base Layer." + triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (!player.IsMoving)
        {
            AnimationTriggerEvent(CPlayer.AnimationTriggerType.PlayerIdle);
            player.StateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
