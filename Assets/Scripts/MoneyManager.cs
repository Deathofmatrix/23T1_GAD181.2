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
        [SerializeField] private TMP_Text moneyUI;

        private void Start()
        {
            currentMoney = 0;
            money = 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("White Sheep"))

            {
                money = 1;
                MoneyCount();
            }

            else if (other.gameObject.CompareTag("Black Sheep"))
            {
                money = 5;
                MoneyCount();
            }

            else money = 0;
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