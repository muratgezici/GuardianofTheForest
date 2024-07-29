using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSpawnerUnit : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;


    public void SpawnEnemy()
    {
        GameObject enemy = GameObject.Instantiate(EnemyPrefab);
        enemy.transform.position = transform.position;
        enemy.SetActive(true);
    }
}
