using SheepGame.Chonnor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


namespace SheepGame.Chonnor
{

    public class ShopManager : MonoBehaviour
    {
        private Vector3 buildingPos;
        public static Transform spawnPoint;
        public static Vector3 newSpawn;
        private GameObject shopPoint;
        [SerializeField] private Canvas shopCanvas;
        public Button upgradeOne, upgradeTwo, upgradeThree;
        [SerializeField] private MoneyManager moneyManager;
        [SerializeField] private GameObject buildingPrefab;
        [SerializeField] private GameObject clickIncreasePrefab;
        [SerializeField] private GameObject spawnIncreasePrefab;
        [SerializeField] private GameObject adjacencyPrefab;

        [SerializeField] private bool devMode = false;

        public UpgradeButton[] upgradeButtonArray;

        private void Start()
        {
            shopCanvas.enabled = false;
            upgradeOne.interactable = false;
            upgradeTwo.interactable = false;
            upgradeThree.interactable = false;
            spawnPoint = GameObject.Find("Building Spawner").GetComponent<Transform>();
            newSpawn = new Vector3(spawnPoint.position.x, spawnPoint.position.y + 5, spawnPoint.position.z);
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
            if (devMode)
            {
                foreach (UpgradeButton button in upgradeButtonArray)
                {
                    button.SetPrice(0);
                }
            }


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
                if (button.GetPrice() > MoneyManager.currentMoney)
                {
                    button.GetComponent<Button>().interactable = false;
                }
                else
                {
                    button.GetComponent<Button>().interactable = true;
                }
            }
        }
        
        public void Upgrade(int price, BuildingType.TypeOfBuilding typeOfBuilding, int increase, Color colour)
        {
            Debug.Log(typeOfBuilding);
            if (GridManager.isBuildingReadyToSpawn)
            {
                switch (typeOfBuilding)
                {
                    case BuildingType.TypeOfBuilding.ClickIncrease:
                        buildingPrefab = clickIncreasePrefab;
                        break;
                    case BuildingType.TypeOfBuilding.SpawnIncreaser:
                        buildingPrefab = spawnIncreasePrefab;
                        break;
                    case BuildingType.TypeOfBuilding.AdjacencyBonus:
                        buildingPrefab = adjacencyPrefab;
                        break;
                    default:
                        break;
                }
                GameObject newbuilding = Instantiate(buildingPrefab, newSpawn, spawnPoint.transform.rotation);
                BuildingType newBuildingType = newbuilding.GetComponent<BuildingType>();
                newBuildingType.SetBuildingStats(typeOfBuilding, increase, true);

                newBuildingType.SetOriginalPosition(newSpawn);

                MeshRenderer mRend = newbuilding.GetComponent<MeshRenderer>();
                mRend.material.color = colour;

                GridManager.isBuildingReadyToSpawn = false;

                MoneyManager.currentMoney -= price;
            }
        }
    }
}