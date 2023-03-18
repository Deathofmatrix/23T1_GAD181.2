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
            if(MoneyManager.currentMoney >= 10)
            {
                upgradeOne.enabled = true;
            }
            // if money counter is higher than 10 then enable)
            if(MoneyManager.currentMoney >= 50)
            {
                upgradeTwo.enabled = true;
            }
            // if money counter is higher than 50 then enable)

            if(MoneyManager.currentMoney >= 100)
            {
                upgradeThree.enabled = true;
            }
            // if money counter is higher than 100 then enable)

        }
        
        public void BuildingGetTest()
        {
            
            Vector3 mousepos = Input.mousePosition;
            mousepos.x = -2.0f;
            buildingPos = Camera.main.ScreenToWorldPoint(mousepos);
            Instantiate(clickPlusOne, buildingPos, Quaternion.identity);
            
        }

        public void UpgradeOne()
        {
            Instantiate(clickPlusOne);

        }
    }
}