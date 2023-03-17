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

        public void MoneyCount()
        {
            // GridManager.totalBonus += money;

        }

        public void Update()
        {
            currentMoney = money;
            moneyUI.SetText(currentMoney.ToString());
        }

    }
}