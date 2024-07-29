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
    private List<GameObject> Enemies = new List<GameObject>();
    private bool IsAutoAimEnabled = false;
    private float _timer = 0f;
    
    private bool isActivated = false;
    public void SetIsWeaponActive(bool _is_active)
    {
        IsWeaponActive = _is_active;
    }
    public bool GetIsWeaponActive()
    {
        return IsWeaponActive;
    }
    public void InitializeWeapon(float _weapon_damage, float _weapon_cooldown, float _weapon_range, float _weapon_fire_amount, bool _is_auto_aim_enabled)
    {
        WeaponDamage += _weapon_damage;
        WeaponCooldown += _weapon_cooldown;
        WeaponRange += _weapon_range;
        WeaponFireAmount += _weapon_fire_amount;
        IsAutoAimEnabled = _is_auto_aim_enabled;
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
        if(!isActivated)
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
                    GameObject closest_enemy = GetClosestEnemy();
                    //Debug.Log(Enemies.Count);
                    if (closest_enemy != null)
                    {
                        GameObject bullet = GameObject.Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
                        bullet.GetComponent<CProjectile>().MoveProjectile(closest_enemy.transform.position, 15f, "Enemy");
                        _timer = 0f;
                    }
                    
                }
                else
                {

                    GameObject closest_enemy = GetClosestEnemy();
                    if (closest_enemy != null)
                    {
                        GameObject bullet = GameObject.Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
                        Debug.Log("MousePos:" + ManualAimDummyTarget.transform.position);
                        bullet.GetComponent<CProjectile>().MoveProjectile(ManualAimDummyTarget.transform.position, 15f, "Enemy");
                        _timer = 0f;
                    }
                    
                }
                
            }
        }
    }

    public GameObject GetClosestEnemy()
    {
        float closest = 1000; //add your max range here
        GameObject closestObject = null;
        for (int i = 0; i < Enemies.Count; i++)  //list of gameObjects to search through
        {
            float dist = Vector3.Distance(Enemies[i].transform.position, transform.position);
            if (dist < closest)
            {
                closest = dist;
                closestObject = Enemies[i];
            }
        }
        return closestObject;
    }
}
