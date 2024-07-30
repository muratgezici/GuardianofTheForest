using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInteractTriggerCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private CPlayer _player;
    private CPlayerUIManager _UImanager;
    private List<GameObject> Interactables = new List<GameObject>();
    private int InteractablesInsideRangeCount = 0;
    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _player = GetComponentInParent<CPlayer>();
        _UImanager = GetComponentInParent<CPlayerUIManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            InteractablesInsideRangeCount++;
            Interactables.Add(collision.gameObject);
            _player.SetInInteractRangeStatus(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            InteractablesInsideRangeCount--;
            Interactables.Remove(collision.gameObject);
            if (InteractablesInsideRangeCount == 0)
            {
                _player.SetInInteractRangeStatus(false);
            }
        }

    }
    private void Update()
    {
        CheckIfInteractablesStillAlive();
        
    }
    private void CheckIfInteractablesStillAlive()
    {
        for (int i = 0; i < Interactables.Count; i++)
        {
            if (Interactables[i].activeSelf == false)
            {
                InteractablesInsideRangeCount--;
                Interactables.RemoveAt(i);
                if (InteractablesInsideRangeCount == 0)
                {
                    _player.SetInInteractRangeStatus(false);
                }
            }
        }
    }
}
