using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class CEnemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable
{
    [field: SerializeField] public float MaxHealth { get; set; } = 10f;
    public float CurrentHealth { get; set; }
    public NavMeshAgent Agent { get; set; }
    public bool IsFacingTowardsPlayer { get; set; } = true;

    public bool IsAggroed { get; set; }
    public bool IsWithinStrikingDistance { get; set; }
    public GameObject BulletPrefab;


    #region State Machine Variables

    public CEnemyStateMachine StateMachine { get; set; }
    public CEnemyIdleState IdleState { get; set; }
    public CEnemyChaseState ChaseState { get; set; }
    public CEnemyAttackState AttackState { get; set; }

    #endregion
    #region Idle Variables
    [SerializeField] float IdleSpeed = 1f;
    [SerializeField] float ChaseSpeed = 6f;
    [SerializeField] public float BulletDamage { get; set; } = 2f;
    public float RandomMovementRange = 5f;
    public float RandomMovementSpeed = 1f;

    #endregion
    protected bool IsGameStopped = false;
    private void SetIsGameStopped(bool val)
    {  
        IsGameStopped = val;
        Debug.Log("enemy: " + IsGameStopped);
    }

    private void Awake()
    {
        StateMachine = new CEnemyStateMachine();

        IdleState = new CEnemyIdleState(this, StateMachine);
        ChaseState = new CEnemyChaseState(this, StateMachine);
        AttackState = new CEnemyAttackState (this, StateMachine);
        CGameManager.IsGamePausedEvent += SetIsGameStopped;

    }
    private void Start()
    {
        CurrentHealth = MaxHealth;
        Agent = GetComponent<NavMeshAgent>();
        StateMachine.Initialize(IdleState);
        AnimationTriggerEvent(CEnemy.AnimationTriggerType.EnemyWalk);
    }
    
    private void Update()
    {
        if (IsGameStopped)
        {
            Agent.speed = 0;
            return;
        }
        StateMachine.CurrentEnemyState.FrameUpdate();
        
    }
    private void FixedUpdate()
    {
        if (IsGameStopped)
        {
            Agent.speed = 0;
            return;
        }
        StateMachine.CurrentEnemyState.PhysicsUpdate();
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
        Destroy(gameObject);
    }
    #endregion
    #region Movement Functions
    public void MoveEnemy(Transform goal, string speed)
    {
        float _speed = 0f;
        if(speed == "Idle")
        {
            _speed = IdleSpeed;
        }
        else if(speed == "Chase")
        {
            _speed = ChaseSpeed;
        }
        else
        {
            _speed = 0f;
        }
        Agent.destination = goal.position;
        Agent.speed = _speed;
        CheckForFacing(goal);
    }

    public void CheckForFacing(Transform goal)
    {
        if (IsFacingTowardsPlayer)
        {
            /*Vector3 rotator = new Vector3(transform.rotation.x, 100f, transform.rotation.z);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, aiLookPosition.rotation, Time.deltaTime);
            transform.rotation = Quaternion.Euler(rotator); */
            transform.LookAt(new Vector3(goal.position.x, transform.position.y, goal.position.z));
            //IsFacingTowardsPlayer = !IsFacingTowardsPlayer;
        }
        

    }

    #endregion

    #region Distance Checks

    public void SetAggroedStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }

    public void SetStrikingDistanceBool(bool isWithinStrikingDistance)
    {
        IsWithinStrikingDistance = isWithinStrikingDistance;
    }
    #endregion
    #region Animation Triggers
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);
    }

    public enum AnimationTriggerType
    {
        EnemyWalk,
        EnemyRun,
        EnemyAttack,
        EnemyIdle,
    }
    #endregion
}
