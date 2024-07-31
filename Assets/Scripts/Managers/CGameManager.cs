using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour
{
    [SerializeField] private GameObject DirectionalLight;
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
        if(!IsGamePaused)
        {
            if(DirectionalLight.GetComponent<Light>().intensity > 0)
            {
                DirectionalLight.GetComponent<Light>().intensity -= Time.deltaTime / 60;
            }
            
        }
    }

}
