using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEvents : MonoBehaviour
{

    private float waitTime = 3f;
    private float dragWaitTime = 6f;
    private bool alreadyShownOne = false;
    private bool alreadyShownTwo = false;
    private bool alreadyShownThree = false;
    // private bool alreadyShownFour = false;

    // public Button upgradeOne;

    [SerializeField] private Image tryButton, watchSheep, moneyUp, tryShop, enoughMoney; //dragNDrop;
    // [SerializeField] private Image tryClicking;

    private void Start()
    {
        StartCoroutine(ScreenTime()); 

        watchSheep.enabled = false;
        moneyUp.enabled = false;
        tryShop.enabled = false;
        enoughMoney.enabled = false;
        
        // dragNDrop.enabled = false;
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



    public void MoneyUp()
    {
        moneyUp.enabled = true;
        alreadyShownOne = true;
        Debug.Log("Now True");
        StartCoroutine(ScreenTimeTwo());
    }

    public void TryShop()
    {
        tryShop.enabled = true;
        alreadyShownTwo = true;
        StartCoroutine(ScrrenTimeThree());
    }

    public void EnoughMoney()
    {
        enoughMoney.enabled = true;
        alreadyShownThree = true;
        StartCoroutine(ScreenTimeFour());
    }

    //public void DragAndDrop()
    //{
      //  dragNDrop.enabled = true;
        //alreadyShownFour = true;
        //StartCoroutine(ScreenTimeFive());
    //}



    IEnumerator ScreenTime()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        tryButton.enabled = false;

        //yield return new WaitForSecondsRealtime(waitTime);
        //watchSheep.enabled = false;
        //yield return new WaitForSecondsRealtime(waitTime);
        //tryClicking.enabled = false;
        //yield return new WaitForSeconds(dragWaitTime);
        //dragNDrop.enabled = false;
    }

    IEnumerator ScreenTimeTwo()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        moneyUp.enabled = false;
    }

    IEnumerator ScrrenTimeThree()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        tryShop.enabled = false;
    }

    IEnumerator ScreenTimeFour()

    {
        yield return new WaitForSecondsRealtime(waitTime);
        enoughMoney.enabled = false;
    }

//    IEnumerator ScreenTimeFive()
//    {
//        yield return new WaitForSeconds(dragWaitTime);
//        dragNDrop.enabled = false;
//    }
    private void Update()
    {

        if (MoneyManager.currentMoney >= 1 && alreadyShownOne == false)
        {
            MoneyUp();
          //  Debug.Log("Money Up");
        }
        //Debug.Log("Return Test");

        if (MoneyManager.currentMoney >= 10 && alreadyShownTwo == false)
        {
            TryShop();
          //  Debug.Log("Money 10");
        }

        if (MoneyManager.currentMoney >= 50 && alreadyShownThree == false)
        {
            EnoughMoney();
        }

        //if (MoneyManager.currentMoney >= 500 && Input.GetButtonDown("Upgrade One") && alreadyShownFour == false)
        //{
        //    DragAndDrop();
        //}
    }
}
