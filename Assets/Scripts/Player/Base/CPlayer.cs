using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CPlayer : MonoBehaviour, IPlayerDamageable, ITriggerPlayerCheckable
{
    [SerializeField] private GameObject ProjectileAttackManager;
    [SerializeField] private GameObject MeleeAttackManager;
    public static event Action PlayerDied;
    public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }
    public bool IsMoving { get; set; }
    public NavMeshAgent Agent { get; set; }

    public bool IsInCollectRange { get; set; }
    public bool IsInTreeCutRange { get; set; }
    public bool IsInInteractRange { get; set; }

    #region State Machine Variables

    public CPlayerStateMachine StateMachine { get; set; }
    public CPlayerIdleState IdleState { get; set; }
    public CPlayerWalkState WalkState { get; set; }
    public CPlayerAttackState AttackState { get; set; }
    public CPlayerCutTreeState CutTreeState { get; set; }
    public CPlayerCollectState CollectState { get; set; }
    public CPlayerInteractState InteractState { get; set; }

    public int MushroomCount { get; set; } = 0;
    public int TreeCount { get; set; } = 0;
    public int FlowerCount { get; set; } = 0;
    #endregion
    private void Awake()
    {
        StateMachine = new CPlayerStateMachine();
        IdleState = new CPlayerIdleState(this, StateMachine);
        WalkState = new CPlayerWalkState(this, StateMachine);
        AttackState = new CPlayerAttackState(this, StateMachine);
        CutTreeState = new CPlayerCutTreeState(this, StateMachine);
        CollectState = new CPlayerCollectState(this, StateMachine);
        InteractState = new CPlayerInteractState(this, StateMachine);

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
    public void Heal(float HealAmount)
    {
        CurrentHealth += HealAmount;
    }
    public void Die()
    {

        PlayerDied?.Invoke();
    }
    #endregion
    #region Collectable Actions
    public void AddMushroom(int amount)
    {
        MushroomCount += amount;
    }
    public void AddFlower(int amount)
    {
        FlowerCount += amount;
    }
    public void AddTree(int amount)
    {
        TreeCount += amount;
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
        PlayerCollect,
        PlayerInteract,
        PlayerCutTree,
    }
    #endregion

    #region Trigger Checks
    public void SetInCollectRangeStatus(bool isInCollectRange)
    {
        IsInCollectRange = isInCollectRange;
    }

    public void SetInTreeCutRangeStatus(bool isInTreeCutRange)
    {
        IsInTreeCutRange = isInTreeCutRange;
    }

    public void SetInInteractRangeStatus(bool isInInteractRange)
    {
        IsInInteractRange = isInInteractRange;
    }

    public GameObject FindClosestObjectWithTag(string tag)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest_obj = null;
        float minDist = Mathf.Infinity;
        foreach (GameObject obj in objs)
        {
            float distance = Vector3.Distance(obj.transform.position, transform.position);
            if(obj.activeSelf == true)
            {
                if (distance < minDist)
                {
                    closest_obj = obj;
                    minDist = distance;
                }
            }
            
        }
        return closest_obj;
    }
    #endregion
}
