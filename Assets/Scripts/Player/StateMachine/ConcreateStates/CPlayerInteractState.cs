using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerInteractState : CPlayerState
{
    public CPlayerInteractState(CPlayer player, CPlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void AnimationTriggerEvent(CPlayer.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
        GameObject obj = player.FindClosestObjectWithTag("Interactable");
        if (obj != null)
        {
            //obj.GetComponent<CCollectableUnit>().ActionCollectCollectable();


        }
        player.StateMachine.ChangeState(player.IdleState);
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
