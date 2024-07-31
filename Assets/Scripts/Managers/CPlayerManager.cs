using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] ProjectileWeapons;
    [SerializeField] private GameObject[] MeleeWeapons;
    [SerializeField] private GameObject ProjectileAttackManager;
    [SerializeField] private GameObject MeleeAttackManager;

    private CProjectileAttackBase ProjectileAttackBase;
    private CMeleeAttackBase MeleeAttackBase;
    private void Start()
    {
        ProjectileAttackBase = ProjectileAttackManager.GetComponent<CProjectileAttackBase>();
        MeleeAttackBase = MeleeAttackManager.GetComponent <CMeleeAttackBase>();
        AssignWeapons();
    }
    private void Update()
    {
        foreach (GameObject weapon in ProjectileWeapons)
        {
            if (!ProjectileAttackBase.GetWeapons().Contains(weapon))
            {
                if (weapon.GetComponent<CWeapon>().GetIsWeaponActive())
                {
                    ProjectileAttackBase.AddWeapon(weapon);
                }
            }
            
        }
        foreach (GameObject weapon in MeleeWeapons)
        {
            if (!MeleeAttackBase.GetWeapons().Contains(weapon))
            {
                if (weapon.GetComponent<CWeapon>().GetIsWeaponActive())
                {

                    MeleeAttackBase.AddWeapon(weapon);
                }
            }
        }
    }
    private void AssignWeapons()
    {
        //For each active projectile weapon, assign it to projectile atack mananger
        foreach(GameObject weapon in ProjectileWeapons)
        {
            
            if(weapon.GetComponent<CWeapon>().GetIsWeaponActive())
            {
                
                ProjectileAttackBase.AddWeapon(weapon);
            }
        }
        foreach (GameObject weapon in MeleeWeapons)
        {
            if (weapon.GetComponent<CWeapon>().GetIsWeaponActive())
            {
               
                MeleeAttackBase.AddWeapon(weapon);
            }
        }
    }
}
