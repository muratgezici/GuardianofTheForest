using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyAttackState : CEnemyState
{
    private float _timer;
    private float _timeBetweenShots = 2f;
    //private float _exitTimer;
    //private float _timeTillExit = 3f;
    //private float _distanceToCountExit = 10f;
    //private float _bulletSpeed = 10f;
    public CEnemyAttackState(CEnemy enemy, CEnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
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
        enemy.MoveEnemy(Player.transform, 0f);
        if(_timer > _timeBetweenShots)
        {
            AnimationTriggerEvent(CEnemy.AnimationTriggerType.EnemyAttack);
            _timer = 0f;
            Vector2 dir = (Player.transform.position - enemy.transform.position).normalized;
            GameObject bullet = GameObject.Instantiate(enemy.BulletPrefab, enemy.transform.position, Quaternion.identity);
            bullet.GetComponent<CProjectile>().MoveProjectile(Player.transform.position, 15f, "Player");

        }
        else if (_timer > _timeBetweenShots / 2f)
        {
            AnimationTriggerEvent(CEnemy.AnimationTriggerType.EnemyIdle);
        }
        
            if(!enemy.IsWithinStrikingDistance)
            {
            AnimationTriggerEvent(CEnemy.AnimationTriggerType.EnemyRun);
            enemy.StateMachine.ChangeState(enemy.ChaseState);
            }
        _timer += Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
