using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SheepGame.Chonnor
{

    public class ShopManager : MonoBehaviour
    {
        private Vector3 buildingPos;
        public Transform spawnPoint;
        private GameObject shopPoint;
        [SerializeField] private Canvas shopCanvas;
        public Button upgradeOne, upgradeTwo, upgradeThree;
        [SerializeField] private MoneyManager moneyManager;
        [SerializeField] private GameObject clickPlusOne;

        void Start()
        {
            shopCanvas.enabled = false;
            upgradeOne.enabled = false;
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
            if(MoneyManager.currentMoney >= 50)
            {
                upgradeOne.enabled = true;
            }
            // if money counter is higher than 10 then enable)
            if(MoneyManager.currentMoney >= 100)
            {
                upgradeTwo.enabled = true;
            }
            // if money counter is higher than 50 then enable)

            if(MoneyManager.currentMoney >= 500)
            {
                upgradeThree.enabled = true;
            }
            // if money counter is higher than 100 then enable)

        }
        
        public void UpgradeOne()
        {
            Instantiate(clickPlusOne, spawnPoint.transform.position, spawnPoint.transform.rotation);
            
            MoneyManager.currentMoney -= 50;
        }
    }
}