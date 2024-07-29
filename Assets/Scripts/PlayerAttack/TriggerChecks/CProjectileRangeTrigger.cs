using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CProjectileRangeTrigger : MonoBehaviour
{
    private CAttackBase _attackManager;
    private int EnemyInsideRangeCount = 0;
    private List<GameObject> Enemies = new List<GameObject>();
    private void Awake()
    {
        _attackManager = GetComponentInParent<CAttackBase>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemies.Add(collision.gameObject);
            EnemyInsideRangeCount++;

            _attackManager.SetProjectileRangeStatus(true);
            _attackManager.UpdateEnemyListOnWeapons(Enemies);


        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Enemies.Remove(collision.gameObject);
            EnemyInsideRangeCount--;

            _attackManager.UpdateEnemyListOnWeapons(Enemies);
            if (EnemyInsideRangeCount == 0)
            {
                _attackManager.SetProjectileRangeStatus(false);
            }
        }

    }
}
