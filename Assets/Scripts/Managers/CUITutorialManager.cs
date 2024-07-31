using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUITutorialManager : MonoBehaviour
{
    [SerializeField] GameObject[] TutorialPages;
    [SerializeField] GameObject EndGamePage;
    [SerializeField] GameObject TutorialPanel;

    private void Start()
    {
        CPlayer.PlayerDied += IsPlayerDied;
    }
    private int index = 0;
    public void OnClickNextPage()
    {
        TutorialPages[index].SetActive(false);
        index++;
        if(index < TutorialPages.Length)
        {
            TutorialPages[index].SetActive(true);
        }
        else
        {
            TutorialPanel.SetActive(false);
            gameObject.GetComponent<CGameManager>().InvokeIsGamePaused();
        }
        
    }
    public void IsPlayerDied()
    {
        EndGamePage.SetActive(true);
    }
}
