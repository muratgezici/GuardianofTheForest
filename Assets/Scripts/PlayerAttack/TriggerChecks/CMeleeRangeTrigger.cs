using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMeleeRangeTrigger : MonoBehaviour
{
    private CAttackBase _attackManager;
    private int EnemyInsideRangeCount = 0;
    [SerializeField] List<GameObject> Enemies = new List<GameObject>();
    private float _timer = 0;
    private float _timer_interval = 2f;
    private void Awake()
    {
        _attackManager = GetComponentInParent<CAttackBase>();
    }

    private void OnTriggerEnter(Collider collision)
    {
      
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyInsideRangeCount++;
            Enemies.Add(collision.gameObject);
            _attackManager.SetMeleeRangeStatus(true);
   
            
            
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemies.Remove(collision.gameObject);
            EnemyInsideRangeCount--;
                if (EnemyInsideRangeCount == 0)
                {
                    _attackManager.SetMeleeRangeStatus(false);
                }
            
               
        }

    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _timer_interval)
        {
            CheckIfEnemyStillAlive();
            _timer = 0;
        }
    }
    private void CheckIfEnemyStillAlive()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i] == null)
            {
                EnemyInsideRangeCount--;
                Enemies.RemoveAt(i);
                if (EnemyInsideRangeCount == 0)
                {
                    _attackManager.SetMeleeRangeStatus(false);
                }
            }
        }
    }
}
