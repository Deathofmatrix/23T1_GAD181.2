using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEvents : MonoBehaviour
{

    private float waitTime = 3f;
    private float dragWaitTime = 6f;

    public Button upgradeOne;

    [SerializeField] private Image tryButton, watchSheep, moneyUp, tryShop, enoughmoney, dragNDrop;
   // [SerializeField] private Image tryClicking;

    private void Start()
    {
        StartCoroutine(ScreenTime()); // not necessary but i wanted to try out a timed message
        // timed messages might be useful later on when we include news reports

        watchSheep.enabled = false;
        moneyUp.enabled = false;
        tryShop.enabled = false;
        enoughmoney.enabled = false;
        dragNDrop.enabled = false;

       // tryClicking.enabled = false;

    }

    private void Awake()
    {
        tryButton.enabled = true;
    }

    public void WatchSheep()
    {
        if (watchSheep != null)
        {
            return;
        }
            
        else
        {
            Destroy(watchSheep);
        }
    }

    /*public void TryClicking()
    {
        tryClicking.enabled = true;
    }*/

    public void MoneyUp()
    {
        moneyUp.enabled = true;
    }

    public void TryShop()
    {
        tryShop.enabled = true;
    }

    public void EnoughMoney()
    {
        enoughmoney.enabled = true;
    }

    public void DragAndDrop()
    {
        dragNDrop.enabled = true;
    }



    IEnumerator ScreenTime()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        tryButton.enabled = false;

        yield return new WaitForSecondsRealtime(waitTime);
        watchSheep.enabled = false;


        yield return new WaitForSecondsRealtime(waitTime);
        moneyUp.enabled = false;

        yield return new WaitForSecondsRealtime(waitTime);
        tryShop.enabled=false;

        yield return new WaitForSecondsRealtime(waitTime);
        enoughmoney.enabled = false;

        //yield return new WaitForSecondsRealtime(waitTime);
        //tryClicking.enabled = false;

        yield return new WaitForSeconds(dragWaitTime);
        dragNDrop.enabled=false;
    }


    private void Update()
    {

         if (MoneyManager.currentMoney >= 1)
        {
            MoneyUp();
        }
        
        if(MoneyManager.currentMoney >= 10)
        {
            TryShop();
        }

         if(MoneyManager.currentMoney >= 50)
        {
            EnoughMoney();
        }

         if (MoneyManager.currentMoney >= 50 && Input.GetButtonDown("Upgrade One"))
        {
            DragAndDrop();
        }
    }
}
