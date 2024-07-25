using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMeleeRangeTrigger : MonoBehaviour
{
    private CAttackBase _attackManager;
    private int EnemyInsideRangeCount = 0;
    private void Awake()
    {
        _attackManager = GetComponentInParent<CAttackBase>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _attackManager.SetMeleeRangeStatus(true);
            EnemyInsideRangeCount++;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyInsideRangeCount--;
            if (EnemyInsideRangeCount == 0)
            {
                _attackManager.SetMeleeRangeStatus(false);
            }
        }

    }
}
