using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CEnemyUIManager : MonoBehaviour
{
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject CurrentHealthBarImage;
    private float CurrentHealth = 0;
    private float MaxHealth = 0;
    CEnemy _Enemy;
    private void Start()
    {
        _Enemy = GetComponentInParent<CEnemy>();
        CurrentHealth = _Enemy.CurrentHealth;
        MaxHealth = _Enemy.MaxHealth;
    }
    private void Update()
    {
        Canvas.transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        SetHealthBarFillAmount();

    }

    private void SetHealthBarFillAmount()
    {
        CurrentHealth = _Enemy.CurrentHealth;
        float fill_amount = CurrentHealth / MaxHealth;
       
        CurrentHealthBarImage.GetComponent<Image>().fillAmount = fill_amount;
        
    }
}
