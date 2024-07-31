using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTreeUnit : MonoBehaviour
{
    private int TreeIndex = 0;
    private bool IsTreeEnabled = false;
    private int Health = 5;
    public void SpawnTree()
    {
        if (!IsTreeEnabled)
        {
            gameObject.SetActive(true);
            transform.GetChild(TreeIndex).gameObject.SetActive(false);
            TreeIndex = Random.Range(0, transform.childCount);
            transform.GetChild(TreeIndex).gameObject.SetActive(true);
            IsTreeEnabled = true;
        }
        

    }
    public int GetTreeHealth()
    {
        return Health;
    }
    public void ActionCutTree()
    {
        Health -= 1;
        if(Health <= 0)
        {
            ActionCutFinished();
        }
    }
    public void ActionCutFinished()
    {
        IsTreeEnabled = false;
        transform.GetChild(TreeIndex).gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
    public bool GetIsTreeEnabled()
    {
        return IsTreeEnabled;
    }
}
