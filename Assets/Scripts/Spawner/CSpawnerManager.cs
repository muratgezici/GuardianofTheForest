using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CSpawnerManager : MonoBehaviour
{
    private List<GameObject> Spawners = new List<GameObject>();
    private float spawn_timer = 0f;
    [SerializeField] private float spawn_timer_interval = 1f;

    private float next_spawner_timer = 0f;
    private float next_spawner_timer_interval = 15f;
    [SerializeField] private bool is_spawner_active = false;
    private bool is_next_spawner_activated = false;
    [SerializeField] private GameObject NextSpawner;
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
        if(!is_spawner_active)
        {
            return;
        }
        if (IsGameStopped)
        {
            return;
        }
        if(!is_next_spawner_activated)
        {
            next_spawner_timer += Time.deltaTime;
            if (next_spawner_timer > next_spawner_timer_interval)
            {
                is_next_spawner_activated = true;
                NextSpawner.SetActive(true);
                NextSpawner.GetComponent<CSpawnerManager>().IsSpawnerActive(true);
                spawn_timer_interval *= 2.5f;
            }
        }
        
        spawn_timer += Time.deltaTime;
        if (spawn_timer > spawn_timer_interval)
        {
            if (spawn_timer_interval > 0.3f)
            {
                spawn_timer_interval -= 0.01f;
            }

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
    public void IsSpawnerActive(bool val)
    {
        is_spawner_active = val;
    }
}
