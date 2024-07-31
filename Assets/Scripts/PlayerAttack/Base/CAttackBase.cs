using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class CAttackBase : MonoBehaviour, IAttackInitializeable, ITriggerAttackCheck
{
    [SerializeField] private List<GameObject> Weapons {  get;  set; } = new List<GameObject>();
    public float WeaponDamage { get; set; } = 0;
    public float WeaponCooldown { get; set; } = 0;
    public float WeaponRange { get; set; } = 0;
    public float WeaponFireAmount { get; set; } = 0;
    public bool IsInMeleeRange { get; set; }
    public bool IsInProjectileRange { get; set; }
    public bool IsAutoAimEnabled { get; set; } = true;

    private bool IsWeaponsFirstTimeInitialized = false;
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
    public List<GameObject> GetWeapons()
    {
        return Weapons;
    }
    public void ActivateWeapons()
    {
        if (!IsWeaponsFirstTimeInitialized)
        {
            IsWeaponsFirstTimeInitialized = true;
            
            InitializeWeapons(WeaponDamage, WeaponCooldown, WeaponRange, WeaponFireAmount, IsAutoAimEnabled, gameObject.GetComponent<CAttackBase>());
        }
        else
        {
            UpdateWeapons(WeaponDamage, WeaponCooldown, WeaponRange, WeaponFireAmount, IsAutoAimEnabled);
        }
        foreach (GameObject _weapon in Weapons)
        {
            _weapon.GetComponent<CWeapon>().ActivateWeapon();
        }
        
    }

    public void DeactivateWeapons()
    {
        foreach (GameObject _weapon in Weapons)
        {
            _weapon.GetComponent<CWeapon>().DeactivateWeapon();
        }
    }

    public void InitializeWeapons(float _weapon_damage, float _weapon_cooldown, float _weapon_range, float _weapon_fire_amount, bool _auto_aim_enabled, CAttackBase attack_base)
    {
        
        foreach (GameObject weapon in Weapons)
        {
            Debug.Log("in foreach: "+attack_base);
            weapon.GetComponent<CWeapon>().InitializeWeapon(_weapon_damage, _weapon_cooldown, _weapon_range, _weapon_fire_amount, _auto_aim_enabled, attack_base);
        }
    }
    public void UpdateWeapons(float _weapon_damage, float _weapon_cooldown, float _weapon_range, float _weapon_fire_amount, bool _auto_aim_enabled)
    {
        foreach (GameObject weapon in Weapons)
        {
            weapon.GetComponent<CWeapon>().UpdateWeapon(_weapon_damage, _weapon_cooldown, _weapon_range, _weapon_fire_amount, _auto_aim_enabled);
        }
    }
    public void UpdateEnemyListOnWeapons(List<GameObject> enemies)
    {
       
        foreach (GameObject weapon in Weapons)
        {
            weapon.GetComponent<CWeapon>().UpdateEnemyList(enemies);
        }
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
