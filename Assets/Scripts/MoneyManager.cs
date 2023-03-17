using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SheepGame.Chonnor
{
    public class MoneyManager : MonoBehaviour
    {
        public static int money;
        private int currentMoney;
        // References to gameObjects which need to talk to it
        private TMP_Text moneyUI;

        private void Start()
        {
            // at the start of the game the currentMoney value is determined to be the value of money, which is ‘i’ plus the current money value
            currentMoney = money + currentMoney;

        }


        public void MoneyCount()
        {
            currentMoney += money;
        }

        public void Update()
        {
            moneyUI.SetText(currentMoney.ToString());
        }

    }
}