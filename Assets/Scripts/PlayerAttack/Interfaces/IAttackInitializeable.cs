using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackInitializeable
{
    void InitializeWeapon(float _weapon_damage, float _weapon_cooldown, float _weapon_range, float _weapon_fire_amount);
    void ActivateWeapon(GameObject weapon);
    void DeactivateWeapon(GameObject weapon);
    void UpdateWeapon(float _weapon_damage, float _weapon_cooldown, float _weapon_range, float _weapon_fire_amount);

    float WeaponDamage { get; set; }
    float WeaponCooldown { get; set; }
    float WeaponRange { get; set; }
    float WeaponFireAmount { get; set; }

}
