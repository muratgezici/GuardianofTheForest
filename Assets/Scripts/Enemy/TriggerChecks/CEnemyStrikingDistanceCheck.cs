using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyStrikingDistanceCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private CEnemy _enemy;

    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _enemy = GetComponentInParent<CEnemy>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == PlayerTarget)
        {
            _enemy.SetStrikingDistanceBool(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == PlayerTarget)
        {
            _enemy.SetStrikingDistanceBool(false);
        }
    }
}
