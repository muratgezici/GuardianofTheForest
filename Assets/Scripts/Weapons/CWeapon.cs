using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWeapon : MonoBehaviour
{
    [SerializeField] private GameObject ProjectilePrefab;
    [SerializeField] private bool IsWeaponActive = false;
    [SerializeField] private float WeaponDamage;
    [SerializeField] private float WeaponCooldown;
    [SerializeField] private float WeaponRange;
    [SerializeField] private float WeaponFireAmount;
    [SerializeField] private GameObject ManualAimDummyTarget;
    [SerializeField] private string WeaponType;
    private List<GameObject> Enemies = new List<GameObject>();
    private CAttackBase AttackBase;
    private bool IsAutoAimEnabled = false;
    private float _timer = 0f;
    private bool IsGameStopped = false;

    private bool isActivated = false;
    public void SetIsWeaponActive(bool _is_active)
    {
        IsWeaponActive = _is_active;
    }
    public bool GetIsWeaponActive()
    {
        return IsWeaponActive;
    }
    private void Start()
    {
        CGameManager.IsGamePausedEvent += SetIsGameStopped;
    }
    public void InitializeWeapon(float _weapon_damage, float _weapon_cooldown, float _weapon_range, float _weapon_fire_amount, bool _is_auto_aim_enabled, CAttackBase attack_base)
    {
        WeaponDamage += _weapon_damage;
        WeaponCooldown += _weapon_cooldown;
        WeaponRange += _weapon_range;
        WeaponFireAmount += _weapon_fire_amount;
        IsAutoAimEnabled = _is_auto_aim_enabled;
        AttackBase = attack_base;
    }
    public void UpdateWeapon(float _weapon_damage, float _weapon_cooldown, float _weapon_range, float _weapon_fire_amount, bool _is_auto_aim_enabled)
    {
        WeaponDamage += _weapon_damage;
        WeaponCooldown += _weapon_cooldown;
        WeaponRange += _weapon_range;
        WeaponFireAmount += _weapon_fire_amount;
        IsAutoAimEnabled = _is_auto_aim_enabled;
    }
    public void UpdateEnemyList(List<GameObject> enemies)
    {
        Enemies.Clear();
        Enemies = enemies;
    }
    public void ActivateWeapon()
    {
        gameObject.SetActive(true);
        isActivated = true;
    }
    public void DeactivateWeapon()
    {
        gameObject.SetActive(false);
        isActivated = false;
    }
    private void Update()
    {
        if (IsGameStopped)
        {
            return;
        }
        if (!isActivated)
        {
            return;
        }
        if (isActivated)
        {
            _timer += Time.deltaTime;
            if (_timer >= WeaponCooldown)
            {
                if(IsAutoAimEnabled)
                {
                    if ((AttackBase.IsInProjectileRange && WeaponType == "Projectile" ) || (AttackBase.IsInProjectileRange && WeaponType == "Melee"))
                    {
                        GameObject closest_enemy = GetClosestEnemy();
                        //Debug.Log(Enemies.Count);
                        if (closest_enemy != null)
                        {
                            GameObject bullet = GameObject.Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
                            bullet.GetComponent<CProjectile>().SetDamage(WeaponDamage);
                            bullet.GetComponent<CProjectile>().MoveProjectile(closest_enemy.transform.position, 15f, "Enemy");
                            _timer = 0f;
                        }
                    }
                    
                    
                }
                else
                {
                    if ((AttackBase.IsInProjectileRange && WeaponType == "Projectile") || (AttackBase.IsInProjectileRange && WeaponType == "Melee"))
                    {
                        GameObject closest_enemy = GetClosestEnemy();
                        if (closest_enemy != null)
                        {
                            GameObject bullet = GameObject.Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
                            Debug.Log("MousePos:" + ManualAimDummyTarget.transform.position);
                            bullet.GetComponent<CProjectile>().SetDamage(WeaponDamage);
                            bullet.GetComponent<CProjectile>().MoveProjectile(ManualAimDummyTarget.transform.position, 15f, "Enemy");
                            _timer = 0f;
                        }
                    }
                      
                    
                }
                
            }
        }
    }

    public GameObject GetClosestEnemy()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest_obj = null;
        float minDist = Mathf.Infinity;
        foreach (GameObject obj in objs)
        {
            float distance = Vector3.Distance(obj.transform.position, transform.position);
            if (obj.activeSelf == true)
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

    private void SetIsGameStopped(bool val)
    {
        IsGameStopped = val;
    }
}
