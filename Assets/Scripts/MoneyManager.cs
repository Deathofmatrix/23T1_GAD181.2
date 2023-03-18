using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

namespace SheepGame.Chonnor
{
    public class MoneyManager : MonoBehaviour
    {
        public static int money;
        private int currentMoney;
        // References to gameObjects which need to talk to it
        [SerializeField] private TMP_Text moneyUI;

        private void Start()
        {
            currentMoney = 0;
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
        }

        public void MoneyCount()
        {
            
            currentMoney += money;
        }

        public void Update()
        {
            
            moneyUI.SetText(money.ToString());
        }

    }
}