using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerCutTreeState : CPlayerState
{
    public CPlayerCutTreeState(CPlayer player, CPlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {
    }

    public override void AnimationTriggerEvent(CPlayer.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
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
        GameObject obj = player.FindClosestObjectWithTag("Tree");
        if (obj != null)
        {
            if (obj.GetComponent<CTreeUnit>().GetTreeHealth() -1 == 0)
            {
                player.AddTree(3);
            }
            obj.GetComponent<CTreeUnit>().ActionCutTree();


        }
        player.StateMachine.ChangeState(player.IdleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
