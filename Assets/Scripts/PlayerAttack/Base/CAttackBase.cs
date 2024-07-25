using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class CAttackBase : MonoBehaviour, IAttackInitializeable, ITriggerAttackCheck
{
   public List<GameObject> Weapons {  get;  set; }
    public float WeaponDamage { get; set; }
    public float WeaponCooldown { get; set; }
    public float WeaponRange { get; set; }
    public float WeaponFireAmount { get; set; }
    public bool IsInMeleeRange { get; set; }
    public bool IsInProjectileRange { get; set; }
    public bool IsAutoAimEnabled { get; set; } = true;

    #region State Machine Variables

    public CAttackStateMachine StateMachine { get; set; }
    public CManualAimAttackState ManualAimState { get; set; }
    public CAutoAimAttackState AutoAimState { get; set; }
   


    #endregion
    private void Awake()
    {
        StateMachine = new CAttackStateMachine();

        ManualAimState = new CManualAimAttackState(this, StateMachine);
        AutoAimState = new CAutoAimAttackState(this, StateMachine);
        

    }
    private void Start()
    {

        StateMachine.Initialize(AutoAimState);
        
    }

    private void Update()
    {
        StateMachine.CurrentAttackState.FrameUpdate();

    }
    private void FixedUpdate()
    {

        StateMachine.CurrentAttackState.PhysicsUpdate();
    }
    #region Weapon Actions
    public void AddWeapon(GameObject weapon)
    {
        Weapons.Add(weapon);
    }
    public void RemoveWeapon(GameObject weapon)
    {
        Weapons.Remove(weapon);
    }
    public void ActivateWeapon(GameObject weapon)
    {
        throw new System.NotImplementedException();
    }

    public void DeactivateWeapon(GameObject weapon)
    {
        throw new System.NotImplementedException();
    }

    public void InitializeWeapon(float _weapon_damage, float _weapon_cooldown, float _weapon_range, float _weapon_fire_amount)
    {
        throw new System.NotImplementedException();
    }
    public void UpdateWeapon(float _weapon_damage, float _weapon_cooldown, float _weapon_range, float _weapon_fire_amount)
    {
        throw new System.NotImplementedException();
    }
    #endregion

    #region Trigger Checks
    public void SetMeleeRangeStatus(bool isInMeleeRange)
    {
        IsInMeleeRange = isInMeleeRange;
    }

    public void SetProjectileRangeStatus(bool isInProjectileRange)
    {
        IsInProjectileRange = isInProjectileRange;
    }

    public void SetAutoAimEnabled(bool isInAutoAimEnabled)
    {
        IsAutoAimEnabled = isInAutoAimEnabled;
    }
    #endregion


}
