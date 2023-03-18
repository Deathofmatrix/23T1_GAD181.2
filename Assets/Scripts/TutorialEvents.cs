using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialEvents : MonoBehaviour
{

    private float waitTime = 3f;

    public Button upgradeOne;

    [SerializeField] private Image tryButton;
    [SerializeField] private Image watchSheep;
    [SerializeField] private Image moneyUp;
    [SerializeField] private Image tryShop;
    [SerializeField] private Image enoughmoney;
    [SerializeField] private Image dragNDrop;

    private void Start()
    {
        StartCoroutine(ScreenTime()); // not necessary but i wanted to try out a timed message
        // timed messages might be useful later on when we include news reports

        watchSheep.enabled = false;
        moneyUp.enabled = false;
        tryShop.enabled = false;
        enoughmoney.enabled = false;
        dragNDrop.enabled = false;
    }

    private void Awake()
    {
        tryButton.enabled = true;
    } 

    public void WatchSheep()
    {
        watchSheep.enabled = true;

    }
    IEnumerator ScreenTime()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        tryButton.enabled = false;

        yield return new WaitForSecondsRealtime(waitTime);
        watchSheep.enabled = false;
    }

    public void DestroyMoneyUp()
    {
        Destroy(moneyUp); 
    }
    public void DestroyTryShop()
    {
        Destroy(tryShop);
    }
    public void DestroyEnoughMoney()
    {
        Destroy(enoughmoney);
    }
    public void DestroyDragNDrop()
    {
        Destroy(dragNDrop);
    }

    private void Update()
    {
        
        if (moneyUp == null)
        {
            return;
        }
        else if (MoneyManager.currentMoney >= 1)
        {
            moneyUp.enabled = true;
        }
        

        if (tryShop == null)
        {
            return;
        }
        else if(MoneyManager.currentMoney >= 10)
        {
            tryShop.enabled = true;
        }

        
        if(enoughmoney == null)
        {
            return;
        }
        else if(MoneyManager.currentMoney >= 50)
        {
            enoughmoney.enabled = true;
        }


        if (dragNDrop == null)
        {
            return;
        }
        else if (MoneyManager.currentMoney >= 50 && Input.GetButtonDown("Upgrade One"))
        {
            dragNDrop.enabled = true;
        }
    }
}
