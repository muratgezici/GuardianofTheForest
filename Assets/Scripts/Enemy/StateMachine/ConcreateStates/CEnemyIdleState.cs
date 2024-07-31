using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyIdleState : CEnemyState
{
    private Vector3 _targetPos;
    private Vector3 _direction;
    private float _speed=1f;
    public CEnemyIdleState(CEnemy enemy, CEnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(CEnemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
        enemy.transform.GetChild(0).GetComponent<Animator>().Play("Base Layer." + triggerType);
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

        if(enemy.IsAggroed)
        {
            AnimationTriggerEvent(CEnemy.AnimationTriggerType.EnemyRun);
            enemy.StateMachine.ChangeState(enemy.ChaseState);

        }
        enemy.MoveEnemy(Player.transform, "Idle");
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    

}
