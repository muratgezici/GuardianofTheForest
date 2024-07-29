using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCollectableUnit : MonoBehaviour
{
    private int CollectableIndex = 0;
    private bool IsCollectableEnabled = false;
    private int Health = 1;
    public void SpawnCollectable()
    {
        if (!IsCollectableEnabled)
        {
            transform.GetChild(CollectableIndex).gameObject.SetActive(false);
            CollectableIndex = Random.Range(0, transform.childCount);
            transform.GetChild(CollectableIndex).gameObject.SetActive(true);
            IsCollectableEnabled = true;
        }


    }
    public void ActionCollectCollectable()
    {
        Health -= 1;
        if (Health <= 0)
        {
            ActionCollectFinished();
        }
    }
    public void ActionCollectFinished()
    {
        IsCollectableEnabled = false;
        transform.GetChild(CollectableIndex).gameObject.SetActive(false);
    }
    public bool GetIsCollectableEnabled()
    {
        return IsCollectableEnabled;
    }
}
