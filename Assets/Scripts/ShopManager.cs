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

        public UpgradeButton[] upgradeButtonArray;

        private void Start()
        {
            shopCanvas.enabled = false;
            upgradeOne.interactable = false;
            upgradeTwo.interactable = false;
            upgradeThree.interactable = false;
        }

        public void OpenShop()
        {
            if (!shopCanvas.enabled)
            {
                shopCanvas.enabled = true;
            }
            else if (shopCanvas.enabled)
            {
                shopCanvas.enabled = false;
            }
        }

        public void CloseShop()
        {
            shopCanvas.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            //if (MoneyManager.currentMoney < 50)
            //{
            //    upgradeOne.interactable = false;
            //    upgradeTwo.interactable = false;
            //    upgradeThree.interactable = false;
            //}
            //if (MoneyManager.currentMoney >= 50)
            //{
            //    upgradeOne.interactable = true;
            //    upgradeTwo.interactable = false;
            //    upgradeThree.interactable = false;
            //}
            //// if money counter is higher than 10 then enable)
            //if (MoneyManager.currentMoney >= 100)
            //{
            //    upgradeTwo.interactable = true;
            //    upgradeThree.interactable = false;
            //}
            //// if money counter is higher than 50 then enable)

            //if (MoneyManager.currentMoney >= 500)
            //{
            //    upgradeThree.interactable = true;
            //}
            //// if money counter is higher than 100 then enable)
            foreach (UpgradeButton button in upgradeButtonArray)
            {
                if (button.GetPrice() >= MoneyManager.currentMoney)
                {
                    button.GetComponent<Button>().interactable = false;
                }
                else
                {
                    button.GetComponent<Button>().interactable = true;
                }
            }
        }
        
        public void Upgrade(int price, BuildingType.TypeOfBuilding typeOfBuilding, int increase)
        {
            if (GridManager.isBuildingReadyToSpawn)
            {
                GameObject newbuilding = Instantiate(clickPlusOne, spawnPoint.transform.position, spawnPoint.transform.rotation);
                BuildingType newBuildingType = newbuilding.GetComponent<BuildingType>();
                newBuildingType.SetBuildingStats(BuildingType.TypeOfBuilding.ClickIncrease, increase);
                GridManager.isBuildingReadyToSpawn = false;

                MoneyManager.currentMoney -= price;
            }
        }
    }
}