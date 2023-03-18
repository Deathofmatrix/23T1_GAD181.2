using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SheepGame.Chonnor
{

    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private Canvas shopCanvas;
        public Button upragdeOne, upgradeTwo, upgradeThree;
        


        void Start()
        {

            upragdeOne.enabled = false;
            upgradeTwo.enabled = false;
            upgradeThree.enabled = false;
        }

        public void OpenShop()
        {
            shopCanvas.enabled = true;
        }

        public void CloseShop()
        {
            shopCanvas.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if(MoneyManager.currentMoney >= 10)
            {
                enabled = true;
            }
            // if money counter is higher than 10 then enable)
            if(MoneyManager.currentMoney >= 50)
            {
                enabled = true;
            }
            // if money counter is higher than 50 then enable)

            if(MoneyManager.currentMoney >= 100)
            {
                enabled = true;
            }
            // if money counter is higher than 100 then enable)

        }


        public void UpgradeOne()
        {
            Instantiate(upragdeOne);
        }
    }
}