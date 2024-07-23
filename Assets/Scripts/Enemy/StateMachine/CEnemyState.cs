using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyState
{
    protected CEnemy enemy;
    protected CEnemyStateMachine EnemyStateMachine;
    protected GameObject Player;

    public CEnemyState(CEnemy enemy, CEnemyStateMachine enemyStateMachine)
    {
        this.enemy = enemy;
        this.EnemyStateMachine = enemyStateMachine;
        this.Player = GameObject.FindWithTag("Player");
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
    public virtual void AnimationTriggerEvent(CEnemy.AnimationTriggerType triggerType)
    {

    }

}
