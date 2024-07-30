using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCollectTriggerCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private CPlayer _player;
    private CPlayerUIManager _UImanager;
    private List<GameObject> Collectables = new List<GameObject>();
    private int CollectablesInsideRangeCount = 0;
    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _player = GetComponentInParent<CPlayer>();
        _UImanager = GetComponentInParent<CPlayerUIManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            CollectablesInsideRangeCount++;
            Collectables.Add(collision.gameObject);
            _player.SetInCollectRangeStatus(true);

        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            CollectablesInsideRangeCount--;
            Collectables.Remove(collision.gameObject);
            if(CollectablesInsideRangeCount == 0)
            {
                _player.SetInCollectRangeStatus(false);
            }
            
        }

    }
    private void Update()
    {
        CheckIfCollectablesStillAlive();
       
    }
    private void CheckIfCollectablesStillAlive()
    {
       
        for (int i = 0; i < Collectables.Count; i++)
        {
            if (Collectables[i].activeSelf == false)
            {
                
                CollectablesInsideRangeCount--;
                Collectables.RemoveAt(i);
                if (CollectablesInsideRangeCount == 0)
                {
                    
                    _player.SetInCollectRangeStatus(false);
                }
            }
        }
    }
}
