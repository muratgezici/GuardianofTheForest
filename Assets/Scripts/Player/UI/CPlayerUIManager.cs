using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerUIManager : MonoBehaviour
{
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject CurrentHealthBarImage;
    private float CurrentHealth = 0;
    private float MaxHealth = 0;
    CPlayer _Player;
    private void Start()
    {
        _Player = GetComponentInParent<CPlayer>();
        CurrentHealth = _Player.CurrentHealth;
        MaxHealth = _Player.MaxHealth;
    }
    private void Update()
    {
        Canvas.transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        SetHealthBarFillAmount();

    }

    private void SetHealthBarFillAmount()
    {
        CurrentHealth = _Player.CurrentHealth;
        float fill_amount = CurrentHealth / MaxHealth;
        Debug.Log(fill_amount);
        CurrentHealthBarImage.GetComponent<Image>().fillAmount = fill_amount;
        Debug.Log(CurrentHealthBarImage.GetComponent<Image>().fillAmount);
    }
}
