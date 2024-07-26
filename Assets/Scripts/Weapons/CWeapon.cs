using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWeapon : MonoBehaviour
{
    [SerializeField] private GameObject ProjectilePrefab;
    [SerializeField] private GameObject Enemy;
    [SerializeField] private bool IsWeaponActive = false;
    [SerializeField] private float WeaponDamage;
    [SerializeField] private float WeaponCooldown;
    [SerializeField] private float WeaponRange;
    [SerializeField] private float WeaponFireAmount;

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
    public void InitializeWeapon(float _weapon_damage, float _weapon_cooldown, float _weapon_range, float _weapon_fire_amount)
    {
        WeaponDamage += _weapon_damage;
        WeaponCooldown += _weapon_cooldown;
        WeaponRange += _weapon_range;
        WeaponFireAmount += _weapon_fire_amount;
    }
    public void UpdateWeapon(float _weapon_damage, float _weapon_cooldown, float _weapon_range, float _weapon_fire_amount)
    {
        WeaponDamage += _weapon_damage;
        WeaponCooldown += _weapon_cooldown;
        WeaponRange += _weapon_range;
        WeaponFireAmount += _weapon_fire_amount;
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
                GameObject bullet = GameObject.Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<CProjectile>().MoveProjectile(Enemy.transform, 15f);
                _timer = 0f;
            }
        }
    }
}
