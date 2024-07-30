using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CSpawnerManager : MonoBehaviour
{
    private List<GameObject> Spawners = new List<GameObject>();
    private float spawn_timer = 0f;
    private float spawn_timer_interval = 3f;
    private bool IsGameStopped = false;
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Spawners.Add(transform.GetChild(i).gameObject);
        }
        CGameManager.IsGamePausedEvent += SetIsGameStopped;
    }
    private void Update()
    {
        if (IsGameStopped)
        {
            return;
        }
        spawn_timer += Time.deltaTime;
        if(spawn_timer > spawn_timer_interval)
        {
            int spawner_index = Random.Range(0, Spawners.Count);
            Spawners[spawner_index].GetComponent<CSpawnerUnit>().SpawnEnemy();
            spawn_timer = 0f;
        }
    }

    private void SetIsGameStopped(bool val)
    {
        IsGameStopped = val;
        Debug.Log("Spawner: "+IsGameStopped);
    }
}
