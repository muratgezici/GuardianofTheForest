using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour
{
    public static event Action<bool> IsGamePausedEvent;
    private bool IsGamePaused = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsGamePaused = !IsGamePaused;
            IsGamePausedEvent?.Invoke(IsGamePaused);
            Debug.Log("Game pause state: " + IsGamePausedEvent.ToString());
            
        }
    }

}
