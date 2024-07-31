using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CGameManager : MonoBehaviour
{
    [SerializeField] private GameObject DirectionalLight;
    public static event Action<bool> IsGamePausedEvent;
    private bool IsGamePaused = false;
    private void Start()
    {
        IsGamePaused = true;
        IsGamePausedEvent?.Invoke(IsGamePaused);
        CPlayer.PlayerDied += IsPlayerDied;
    }
    private void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            IsGamePaused = !IsGamePaused;
            IsGamePausedEvent?.Invoke(IsGamePaused);
            Debug.Log("Game pause state: " + IsGamePausedEvent.ToString());
            
        }*/
        if(!IsGamePaused)
        {
            if(DirectionalLight.GetComponent<Light>().intensity > 0)
            {
                DirectionalLight.GetComponent<Light>().intensity -= Time.deltaTime / 60;
            }
            
        }
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void InvokeIsGamePaused()
    {
        IsGamePaused = !IsGamePaused;
        IsGamePausedEvent?.Invoke(IsGamePaused);
    }
    public void IsPlayerDied()
    {
        IsGamePaused = !IsGamePaused;
        IsGamePausedEvent?.Invoke(IsGamePaused);
    }

}
