using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCollectTriggerCheck : MonoBehaviour
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
        if (collision.gameObject.tag == "Collectable")
        {
            _player.SetInCollectRangeStatus(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            _player.SetInCollectRangeStatus(false);
        }

    }
}
