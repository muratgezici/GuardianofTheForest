using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAimTypeSetter : MonoBehaviour
{
    private CAttackBase _attackManager;
    private bool IsAutoAimEnabled = true;
    private void Awake()
    {
        _attackManager = GetComponentInParent<CAttackBase>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            IsAutoAimEnabled = !IsAutoAimEnabled;
            _attackManager.SetAutoAimEnabled(IsAutoAimEnabled);
        }
    }
}
