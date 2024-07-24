using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInteractTriggerCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private CPlayer _player;
    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
        _player = GetComponentInParent<CPlayer>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            _player.SetInInteractRangeStatus(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            _player.SetInInteractRangeStatus(false);
        }

    }
}
