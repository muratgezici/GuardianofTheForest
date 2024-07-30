using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAimTypeSetter : MonoBehaviour
{
    private CAttackBase _attackManager;
    private bool IsAutoAimEnabled = true;
    private bool IsGameStopped = false;
    private void Awake()
    {
        _attackManager = GetComponentInParent<CAttackBase>();
        CGameManager.IsGamePausedEvent += SetIsGameStopped;
    }

    private void Update()
    {
        if (IsGameStopped)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            IsAutoAimEnabled = !IsAutoAimEnabled;
            _attackManager.SetAutoAimEnabled(IsAutoAimEnabled);
        }
    }

    private void SetIsGameStopped(bool val)
    {
        IsGameStopped = val;
    }
}
