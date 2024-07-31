using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerCollectState : CPlayerState
{
    public CPlayerCollectState(CPlayer player, CPlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
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
        GameObject obj = player.FindClosestObjectWithTag("Collectable");
        if(obj != null)
        {
            
            if(obj.transform.GetChild(1).gameObject.activeSelf == true)
            {
                player.Heal(15f);
            }
            else if(obj.transform.GetChild(0).gameObject.activeSelf == true)
            {
                player.AddMushroom(1);
            }
            else if (obj.transform.GetChild(2).gameObject.activeSelf == true)
            {
                player.AddFlower(1);
            }
            obj.GetComponent<CCollectableUnit>().ActionCollectCollectable();


        }
        player.StateMachine.ChangeState(player.IdleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
