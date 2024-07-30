using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTreeCutTriggerCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private CPlayer _player;
    private CPlayerUIManager _UImanager;
    private List<GameObject> Trees = new List<GameObject>();
    private int TreesInsideRangeCount = 0;
    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _player = GetComponentInParent<CPlayer>();
        _UImanager = GetComponentInParent<CPlayerUIManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            TreesInsideRangeCount++;
            Trees.Add(collision.gameObject);
            _player.SetInTreeCutRangeStatus(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            TreesInsideRangeCount--;
            Trees.Remove(collision.gameObject);
            if (TreesInsideRangeCount == 0)
            {
                _player.SetInTreeCutRangeStatus(false);
            }
            
        }

    }

    private void Update()
    {
        CheckIfTreeStillAlive();
       
    }
    private void CheckIfTreeStillAlive()
    {
        for (int i = 0; i < Trees.Count; i++)
        {
            if (Trees[i].activeSelf == false)
            {
                TreesInsideRangeCount--;
                Trees.RemoveAt(i);
                if (TreesInsideRangeCount == 0)
                {
                    _player.SetInTreeCutRangeStatus(false);
                }
            }
        }
    }
}
