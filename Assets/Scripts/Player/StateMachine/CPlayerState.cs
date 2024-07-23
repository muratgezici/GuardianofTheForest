using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerState 
{
    protected CPlayer player;
    protected CPlayerStateMachine PlayerStateMachine;
    

    public CPlayerState(CPlayer player, CPlayerStateMachine playerStateMachine)
    {
        this.player = player;
        this.PlayerStateMachine = playerStateMachine;
        
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
