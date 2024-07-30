using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerIdleState : CPlayerState
{
    public CPlayerIdleState(CPlayer player, CPlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void AnimationTriggerEvent(CPlayer.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
        player.transform.GetChild(0).GetComponent<Animator>().Play("Base Layer."+triggerType);
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

        if (player.IsMoving)
        {
            AnimationTriggerEvent(CPlayer.AnimationTriggerType.PlayerWalk);
            player.StateMachine.ChangeState(player.WalkState);
        }
        if(player.IsInCollectRange && Input.GetKeyDown(KeyCode.Q))
        {
            AnimationTriggerEvent(CPlayer.AnimationTriggerType.PlayerCollect);
            player.StateMachine.ChangeState(player.CollectState);
        }
        else if(player.IsInInteractRange && Input.GetKeyDown(KeyCode.F))
        {
            AnimationTriggerEvent(CPlayer.AnimationTriggerType.PlayerInteract);
            player.StateMachine.ChangeState(player.InteractState);
        }
        else if (player.IsInTreeCutRange && Input.GetKeyDown(KeyCode.E))
        {
            AnimationTriggerEvent(CPlayer.AnimationTriggerType.PlayerCutTree);
            player.StateMachine.ChangeState(player.CutTreeState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
