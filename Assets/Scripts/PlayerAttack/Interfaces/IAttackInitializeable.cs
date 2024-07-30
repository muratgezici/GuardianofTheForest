using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackInitializeable
{
    void InitializeWeapons(float _weapon_damage, float _weapon_cooldown, float _weapon_range, float _weapon_fire_amount, bool _is_auto_aim_enabled, CAttackBase attack_base);
    void ActivateWeapons();
    void DeactivateWeapons();
    void UpdateWeapons(float _weapon_damage, float _weapon_cooldown, float _weapon_range, float _weapon_fire_amount, bool _is_auto_aim_enabled);
    void UpdateEnemyListOnWeapons(List<GameObject> enemies);
    float WeaponDamage { get; set; }
    float WeaponCooldown { get; set; }
    float WeaponRange { get; set; }
    float WeaponFireAmount { get; set; }

}
