using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerUIManager : MonoBehaviour
{
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject CurrentHealthBarImage;
    [SerializeField] GameObject ImageKeyE;
    [SerializeField] GameObject ImageKeyQ;
    [SerializeField] GameObject ImageKeyC;
    [SerializeField] GameObject ImageKeyM;
    [SerializeField] GameObject ImageKeyN;
    [SerializeField] GameObject MushroomText;
    [SerializeField] GameObject TreeText;
    [SerializeField] GameObject FlowerText;
    [SerializeField] GameObject KilledEnemiesText;
    private float CurrentHealth = 0;
    private float MaxHealth = 0;
    private float KilledEnemies = 0;
    CPlayer _Player;
    private void Start()
    {
        _Player = GetComponentInParent<CPlayer>();
        CurrentHealth = _Player.CurrentHealth;
        MaxHealth = _Player.MaxHealth;
        CEnemy.EnemyDied += OneEnemyDied;
    }
    private void Update()
    {
        Canvas.transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        CurrentHealthBarImage.GetComponent<Image>().material.renderQueue = 2999;
        SetHealthBarFillAmount();

        if (_Player.IsInCollectRange && !_Player.IsMoving)
        {
            ImageKeyQ.SetActive(true);
            if (Input.GetKey(KeyCode.Q))
            {
                ImageKeyQ.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                ImageKeyQ.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            ImageKeyQ.SetActive(false);
        }
        if(_Player.IsInTreeCutRange && !_Player.IsMoving)
        {
            ImageKeyE.SetActive(true);
            if(Input.GetKey(KeyCode.E))
            {
                ImageKeyE.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                ImageKeyE.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            ImageKeyE.SetActive(false);
        }
        if(_Player.IsInInteractRange && !_Player.IsMoving)
        {

        }
        SetCollectablesText();

        if(_Player.MushroomCount >= 1 && _Player.TreeCount >= 1)
        {
            ImageKeyM.SetActive(true);
        }
        else
        {
            ImageKeyM.SetActive(false);
        }
        if (_Player.FlowerCount >= 1 && _Player.TreeCount >= 1)
        {
            ImageKeyN.SetActive(true);
        }
        else
        {
            ImageKeyN.SetActive(false);
        }

        if (Input.GetMouseButtonDown(1))
            {
                ImageKeyM.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                ImageKeyM.transform.GetChild(0).gameObject.SetActive(false);
            }
            if (Input.GetMouseButtonDown(0))
            {
                ImageKeyN.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                ImageKeyN.transform.GetChild(0).gameObject.SetActive(false);
            }


    }
    private void SetCollectablesText()
    {
        MushroomText.GetComponent<TextMeshProUGUI>().text = ""+_Player.MushroomCount;
        TreeText.GetComponent<TextMeshProUGUI>().text = "" + _Player.TreeCount;
        FlowerText.GetComponent<TextMeshProUGUI>().text = "" + _Player.FlowerCount;
    }
    private void SetHealthBarFillAmount()
    {
        CurrentHealth = _Player.CurrentHealth;
        float fill_amount = CurrentHealth / MaxHealth;
        CurrentHealthBarImage.GetComponent<Image>().fillAmount = fill_amount;      
    }
    private void OneEnemyDied()
    {
        KilledEnemies++;
        KilledEnemiesText.GetComponent<TextMeshProUGUI>().text = "Killed Enemies: " + KilledEnemies;
    }
}
