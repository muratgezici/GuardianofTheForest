using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCollectableManager : MonoBehaviour
{
    private List<GameObject> CollectablePrefab = new List<GameObject>();
    private float spawn_timer = 0f;
    private float spawn_timer_interval = 2.5f;
    private bool IsGameStopped = false;
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            CollectablePrefab.Add(transform.GetChild(i).gameObject);
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
        if (spawn_timer > spawn_timer_interval)
        {
            bool is_tree_set = true;
            int time_repeated = 0;
            while (is_tree_set && time_repeated < 10)
            {
                int spawner_index = Random.Range(0, CollectablePrefab.Count);
                is_tree_set = CollectablePrefab[spawner_index].GetComponent<CCollectableUnit>().GetIsCollectableEnabled();
                CollectablePrefab[spawner_index].GetComponent<CCollectableUnit>().SpawnCollectable();
                time_repeated++;
            }


            spawn_timer = 0f;
        }
    }
    private void SetIsGameStopped(bool val)
    {
        IsGameStopped = val;
    }
}
