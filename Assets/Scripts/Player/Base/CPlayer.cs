using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CPlayer : MonoBehaviour, IPlayerDamageable
{
    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public bool IsMoving { get; set; }
    public NavMeshAgent Agent { get; set; }
    #region State Machine Variables

    public CPlayerStateMachine StateMachine { get; set; }
    public CPlayerIdleState IdleState { get; set; }
    public CPlayerWalkState WalkState { get; set; }
    public CPlayerAttackState AttackState { get; set; }
    public CPlayerCutTreeState CutTreeState { get; set; }
    public CPlayerCollectState CollectState { get; set; }

    #endregion
    private void Awake()
    {
        StateMachine = new CPlayerStateMachine();
        IdleState = new CPlayerIdleState(this, StateMachine);
        WalkState = new CPlayerWalkState(this, StateMachine);
        AttackState = new CPlayerAttackState(this, StateMachine);
        CutTreeState = new CPlayerCutTreeState(this, StateMachine);
        CollectState = new CPlayerCollectState(this, StateMachine);

    }
    private void Start()
    {
        CurrentHealth = MaxHealth;
        Agent = GetComponent<NavMeshAgent>();
        StateMachine.Initialize(IdleState);
    }
    private void Update()
    {
        StateMachine.CurrentPlayerState.FrameUpdate();

    }
    private void FixedUpdate()
    {

        StateMachine.CurrentPlayerState.PhysicsUpdate();
    }
    #region Health Die functions
    public void Damage(float DamageAmount)
    {
        CurrentHealth -= DamageAmount;
        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        //
    }
    #endregion

    #region IfChecks
    public void SetMovingStatus(bool isMoving)
    {
        IsMoving = isMoving;
    }
    #endregion

    #region Animation Triggers
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentPlayerState.AnimationTriggerEvent(triggerType);
    }

    public enum AnimationTriggerType
    {
        PlayerIdle,
        PlayerWalk,
    }
    #endregion
}
