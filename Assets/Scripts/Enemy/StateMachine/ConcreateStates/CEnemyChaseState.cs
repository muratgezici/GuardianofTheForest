using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyChaseState : CEnemyState
{
    private float _speed = 6f;

    public CEnemyChaseState(CEnemy enemy, CEnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
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
        enemy.MoveEnemy(Player.transform, "Chase");
        if (enemy.IsWithinStrikingDistance)
        {
            AnimationTriggerEvent(CEnemy.AnimationTriggerType.EnemyIdle);
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }
        else if (!enemy.IsAggroed)
        {
            AnimationTriggerEvent(CEnemy.AnimationTriggerType.EnemyWalk);
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
